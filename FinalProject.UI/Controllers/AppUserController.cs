using AutoMapper;
using FinalProject.BLL.DTOs.AppUserDTOs;
using FinalProject.BLL.Services.AppUserServices;
using FinalProject.UI.Models.VMs.AppUserVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FinalProject.UI.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAppUserService userService;

        public AppUserController(IMapper mapper, IAppUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM) 
        {
            if (ModelState.IsValid)
            {
                var registerDTO = mapper.Map<RegisterDTO>(registerVM);
                var fullName = registerVM.Email.Split(".");
                var firstName= fullName[0];
                var lastName = fullName[1].Split("@")[0];
                registerDTO.FirstName = firstName;
                registerDTO.LastName = lastName;
                var result = await userService.Register(registerDTO);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var loginDTO = mapper.Map<LoginDTO>(loginVM);
                var result = await userService.Login(loginDTO);
                if (result)
                    return RedirectToAction("Index","Home");
            }
            return BadRequest();
        }

        public async Task<IActionResult> LogOut()
        {
            userService.Logout();
            return RedirectToAction("Index");
        }
    }
}
