using BLL.IService;
using DAL.Entities;
using DAL.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Teacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IAuthService authService, UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register register)
        {
            try
            {
                var result = await _authService.RegisterAsync(register);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                return Ok(await _authService.LoginAsync(login));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [HttpPatch("Update")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Update(Update update)
        {
            try
            {
                var Id = User.FindFirstValue("uid");
                var ApplicationUser=await _userManager.FindByIdAsync(Id);
                return Ok(await _authService.UpdateAsync(update,ApplicationUser));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [HttpPatch("ChangePassword")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> ChangePassword(Password password)
        {
            try
            {
                var Id = User.FindFirstValue("uid");
                return Ok(await _authService.ChangePassWordAsync(password, Id));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Authorize(Roles = "Student")]
        [HttpGet("PersonInfo")]
        public async Task<IActionResult> PersonInfo()
        {
            try
            {
                var Id = User.FindFirstValue("uid");
                return Ok(await _userManager.FindByIdAsync(Id));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
