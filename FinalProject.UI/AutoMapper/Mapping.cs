using AutoMapper;
using FinalProject.BLL.DTOs.AppUserDTOs;
using FinalProject.BLL.DTOs.KonuDTOs;
using FinalProject.BLL.DTOs.MakaleDTOs;
using FinalProject.UI.Models.VMs.AppUserVM;
using FinalProject.UI.Models.VMs.KonuVM;
using FinalProject.UI.Models.VMs.MakaleVM;

namespace FinalProject.UI.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<RegisterDTO, RegisterVM>().ReverseMap();
            CreateMap<LoginDTO, LoginVM>().ReverseMap();

            CreateMap<CreateMakaleDTO, CreateMakaleVM>().ReverseMap();
            CreateMap<UpdateMakaleDTO, UpdateMakaleVM>().ReverseMap();
            CreateMap<MakaleListDTO, MakaleListVM>().ReverseMap();
            CreateMap<MakaleDTO, UpdateMakaleVM>().ReverseMap();
            CreateMap<MakaleDTO, MakaleDetailVM>().ReverseMap();

            CreateMap<CreateKonuDTO, CreateKonuVM>().ReverseMap();
            CreateMap<UpdateKonuDTO, UpdateKonuVM>().ReverseMap();
            CreateMap<KonuListDTO, KonuListVM>().ReverseMap();
            CreateMap<UpdateKonuVM, KonuListDTO>().ReverseMap();
        }
    }
}
