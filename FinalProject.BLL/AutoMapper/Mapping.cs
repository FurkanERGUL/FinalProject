using AutoMapper;
using FinalProject.BLL.DTOs.AppUserDTOs;
using FinalProject.BLL.DTOs.KonuDTOs;
using FinalProject.BLL.DTOs.MakaleDTOs;
using FinalProject.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, LoginDTO>().ReverseMap();
            CreateMap<AppUser, RegisterDTO>().ReverseMap();

            CreateMap<Makale, CreateMakaleDTO>().ReverseMap();
            CreateMap<Makale, MakaleListDTO>().ReverseMap();
            CreateMap<Makale, UpdateMakaleDTO>().ReverseMap();
            CreateMap<Makale, MakaleDTO>().ReverseMap();

            CreateMap<Konu, KonuListDTO>().ReverseMap();
            CreateMap<Konu, CreateKonuDTO>().ReverseMap();
            CreateMap<Konu, UpdateKonuDTO>().ReverseMap();
        }
    }
}
