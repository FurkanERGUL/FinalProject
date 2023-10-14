using AutoMapper;
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
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper mapper;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.mapper = mapper;
        }

        public async Task<bool> Login(LoginDTO loginDTO)
        {
            var user =await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user!=null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, true, false);
                return result.Succeeded;
                
            }
            return false;
        }

        public async Task<IdentityResult> Register(RegisterDTO model)
        {
            AppUser appUser = mapper.Map<AppUser>(model);
            var result = await _userManager.CreateAsync(appUser, model.Password);

            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AppUser> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }
    }
}
