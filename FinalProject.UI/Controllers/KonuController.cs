using AutoMapper;
using FinalProject.BLL.DTOs.KonuDTOs;
using FinalProject.BLL.Services.KonuService;
using FinalProject.BLL.Services.MakaleService;
using FinalProject.UI.Models.VMs.KonuVM;
using FinalProject.UI.Models.VMs.MakaleVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.UI.Controllers
{
    public class KonuController : Controller
    {
        private readonly IMapper mapper;
        private readonly IKonuService service;
        private readonly IMakaleService makaleService;

        public KonuController(IMapper mapper, IKonuService service, IMakaleService makaleService)
        {
            this.mapper = mapper;
            this.service = service;
            this.makaleService = makaleService;
        }

        public IActionResult Index()
        {
            var konular = service.GetAll();
            var konularVM = mapper.Map<List<KonuListVM>>(konular);
            return View(konularVM);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateKonuVM konuVM)
        {
            var konuDTO = mapper.Map<CreateKonuDTO>(konuVM);
            if (service.Add(konuDTO))
                return RedirectToAction("Index");
            return View(konuVM);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var konu = service.GetById(id);
            var konuUpdateVM = mapper.Map<UpdateKonuVM>(konu);
            return View(konuUpdateVM);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(UpdateKonuVM konuVM)
        {
            var konu = mapper.Map<UpdateKonuDTO>(konuVM);
            var result = service.Update(konu);
            if (result)
                return RedirectToAction("Index");
            return View(konuVM);
        }

        public IActionResult Makaleler(int id)
        {
            var makaleler = makaleService.GetAll().Where(x => x.KonuId == id);
            var makalelerVM = mapper.Map<List<MakaleListVM>>(makaleler);
            return View(makalelerVM);
        }
    }
}
