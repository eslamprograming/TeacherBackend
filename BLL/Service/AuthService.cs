using BLL.Helper;
using BLL.IService;
using DAL.Data;
using DAL.Entities;
using DAL.Models.Sheard;
using DAL.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWT _jwt;
        private readonly ApplicationDbContext db;
        public AuthService(UserManager<ApplicationUser> UserManager, IOptions<JWT> jwt, ApplicationDbContext db)
        {
            _userManager = UserManager;
            _jwt = jwt.Value;
            this.db = db; ;
        }
        public async Task<Auth> RegisterAsync(Register model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new Auth { Message = "Email is already registered!" };

            if (await _userManager.FindByNameAsync(model.UserName) is not null)
                return new Auth { Message = "Username is already registered!"};

  

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber=model.Phone,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new Auth { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "Student");


            var jwtSecurityToken = await CreateJwtToken(user);


            await _userManager.UpdateAsync(user);
            var studentRoles = await _userManager.GetRolesAsync(user);

            Student student = new Student();
            student.ApplicationUserId = user.Id;
            student.User = user;
            student.SubjectID = model.SubjectId;
            db.Students.Add(student);
            await db.SaveChangesAsync();

            return new Auth
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = studentRoles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName

            };
        }
        public async Task<Auth> LoginAsync(Login loginUser)
        {
            // Check if email or password true or not
            var user = await _userManager.FindByEmailAsync(loginUser.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginUser.Password))
                return new() { Message = "Invalid password or email" };


            // create token for the user
            var jwtSecurityToken = await CreateJwtToken(user);
            var studentRoles = await _userManager.GetRolesAsync(user);


            return new Auth
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = studentRoles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        public async Task<Auth> UpdateAsync(Update userUpdate, ApplicationUser user)
        {
            user.FirstName = userUpdate.FirstName;
            user.LastName = userUpdate.LastName;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new Auth { Message = errors };
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var studentRoles = await _userManager.GetRolesAsync(user);

            return new Auth
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = studentRoles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };
        }

        public async Task<Auth> ChangePassWordAsync(Password password,string Id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(Id);
                var result = await _userManager.ChangePasswordAsync(user, password.OldPassword, password.NewPassword);
                if (result.Succeeded)
                {
                    var user2 = await _userManager.FindByIdAsync(Id);
                    var jwtSecurityToken = await CreateJwtToken(user2);
                    var studentRoles = await _userManager.GetRolesAsync(user2);
                    return new Auth
                    {
                        Email = user.Email,
                        ExpiresOn = jwtSecurityToken.ValidTo,
                        IsAuthenticated = true,
                        Roles = studentRoles.ToList(),
                        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                        Username = user.UserName
                    };
                }
                else
                {
                    var errors = string.Empty;

                    foreach (var error in result.Errors)
                        errors += $"{error.Description},";

                    return new Auth { Message = errors };
                }

            }
            catch (Exception e)
            {
                return new Auth
                {
                    Message = e.Message
                };
            }
        }
    }
}
