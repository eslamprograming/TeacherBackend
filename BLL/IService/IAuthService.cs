using DAL.Entities;
using DAL.Models.Sheard;
using DAL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IAuthService
    {
        Task<Auth> RegisterAsync(Register model);
        Task<Auth> LoginAsync(Login loginuser);
        Task<Auth> UpdateAsync(Update userUpdate, ApplicationUser user);
        Task<Auth> ChangePassWordAsync(Password password, string Id);
    }
}
