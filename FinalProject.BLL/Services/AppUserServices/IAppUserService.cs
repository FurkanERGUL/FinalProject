using FinalProject.BLL.DTOs.AppUserDTOs;
using FinalProject.CORE.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Services.AppUserServices
{
    public interface IAppUserService
    {
        public Task<IdentityResult> Register(RegisterDTO model);
        public Task<bool> Login(LoginDTO loginDTO);
        public Task Logout();
        public Task<AppUser> GetUser(string id);
    }
}
