using AutoMapper;
using FinalProject.BLL.DTOs.MakaleDTOs;
using FinalProject.BLL.Services.AppUserServices;
using FinalProject.BLL.Services.KonuService;
using FinalProject.BLL.Services.MakaleService;
using FinalProject.UI.Models.VMs.KonuVM;
using FinalProject.UI.Models.VMs.MakaleVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject.UI.Controllers
{
    public class MakaleController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMakaleService service;
        private readonly IAppUserService appUserService;
        private readonly IKonuService konuService;

        public MakaleController(IMapper mapper, IMakaleService service, IAppUserService appUserService, IKonuService konuService)
        {
            this.mapper = mapper;
            this.service = service;
            this.appUserService = appUserService;
            this.konuService = konuService;
        }

        public IActionResult Index()
        {
            IList<MakaleListVM> makaleListVM = RandomMakaleList();
            if (User.Identity.IsAuthenticated)
            {
                return View(makaleListVM);
            }
            return View(makaleListVM);
        }

        

        [Authorize]
        [HttpGet]
        public IActionResult Create() 
        {
            var konularDTO = konuService.GetAll();
            var konularVM = mapper.Map<List<KonuListVM>>(konularDTO);
            CreateMakaleVM makaleVM = new CreateMakaleVM()
            {
                Konular = konularVM
            };

            return View(makaleVM);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateMakaleVM makaleVM)
        {
            CreateMakaleDTO makaleDTO = mapper.Map<CreateMakaleDTO>(makaleVM);
            var writerID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await appUserService.GetUser(writerID);
            makaleDTO.WriterName = user.FirstName+" "+user.LastName;
            makaleDTO.ReadingTime = makaleDTO.Content.Length/2;
            makaleDTO.AppUserId =writerID;
            var result = service.Add(makaleDTO);
            if (result)
                return RedirectToAction("Index");
            return View(makaleVM);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var makaleDTO = service.GetById(id);
            if (makaleDTO != null)
            {
                var makaleVM = mapper.Map<UpdateMakaleVM>(makaleDTO);
                var konularDTO = konuService.GetAll();
                var konularVM = mapper.Map<List<KonuListVM>>(konularDTO);
                makaleVM.Konular = konularVM;
                return View(makaleVM);
            }    
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(UpdateMakaleVM makaleVM)
        {
            UpdateMakaleDTO makaleDTO = mapper.Map<UpdateMakaleDTO> (makaleVM);
            var result = service.Update(makaleDTO);
            if (result)
                return RedirectToAction("Index");
            return View(makaleVM);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(MakaleListVM makaleVM)
        {
            MakaleListDTO makaleDTO = mapper.Map<MakaleListDTO>(makaleVM);
            service.Delete(makaleDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var makale = service.GetById(id);
            var makaleVM = mapper.Map<MakaleDetailVM>(makale);
            return View(makaleVM);
        }



        /// <summary>
        /// Rastgele bir liste oluşması ve 20 den fazla veri girişi olmaması içiçn hazırladığım fonksiyon
        /// </summary>
        /// <returns></returns>
        private IList<MakaleListVM> RandomMakaleList()
        {
            var random = new Random();
            int sayac = 0;
            var makaleListDTO = service.GetAll();
            var AllMakaleListVM = mapper.Map<IList<MakaleListVM>>(makaleListDTO);
            IList<MakaleListVM> makaleListVM = new List<MakaleListVM>();
            foreach (var item in AllMakaleListVM)
            {
                var randomNumber = random.Next(AllMakaleListVM.Count);
                makaleListVM.Add(AllMakaleListVM[randomNumber]);
                if (sayac == 20 || sayac > 20)
                    break;
            }

            return makaleListVM;
        }
    }
}
