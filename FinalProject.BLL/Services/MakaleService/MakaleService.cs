using AutoMapper;
using FinalProject.BLL.DTOs.MakaleDTOs;
using FinalProject.BLL.Services.BaseServices;
using FinalProject.CORE.Concrete;
using FinalProject.CORE.Repositories;
using FinalProject.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Services.MakaleService
{
    public class MakaleService : IMakaleService
    {
        private readonly IMakaleRepo repo;
        private readonly IMapper mapper;

        public MakaleService(IMakaleRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public bool Add(CreateMakaleDTO entity)
        {
            var makale = mapper.Map<Makale>(entity);
            if (makale is not null)
            {
                var result = repo.Add(makale);
                return result;
            }
            return false;
        }

        public bool Any(Expression<Func<Makale, bool>> filter)
        {
            return repo.Any(filter);
        }

        public void Delete(MakaleListDTO entity)
        {
            var makale = mapper.Map<Makale>(entity);
            if (makale is not null)
            {
                repo.Delete(makale);
            }
        }

        public IList<MakaleListDTO> GetAll()
        {
            var makaleList = repo.GetAll();
            var makaleListDTO = mapper.Map<List<MakaleListDTO>>(makaleList);
            return makaleListDTO;
        }

        public MakaleDTO GetById(int id)
        {
            var makale = repo.GetById(id);
            var makaleDTO = mapper.Map<MakaleDTO>(makale);
            return makaleDTO;
        }

        public bool Update(UpdateMakaleDTO entity)
        {
            var makale = repo.GetById(entity.Id);
            makale = mapper.Map<Makale>(entity);
            if (makale is not null)
            {
                var result = repo.Update(makale);
                return result;
            }
            return false;
        }


    }
}
