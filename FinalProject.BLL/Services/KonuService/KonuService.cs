using AutoMapper;
using FinalProject.BLL.DTOs.KonuDTOs;
using FinalProject.CORE.Concrete;
using FinalProject.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Services.KonuService
{
    public class KonuService : IKonuService
    {
        private readonly IMapper mapper;
        private readonly IKonuRepo repo;

        public KonuService(IMapper mapper, IKonuRepo repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        public bool Add(CreateKonuDTO entity)
        {
            var konu = mapper.Map<Konu>(entity);
            if (konu is not null)
                return repo.Add(konu);
            return true;
        }

        public bool Any(Expression<Func<Konu, bool>> filter)
        {
            return repo.Any(filter);
        }

        public void Delete(KonuListDTO entity)
        {
            var konu = mapper.Map<Konu>(entity);
            if (konu is not null)
                repo.Delete(konu);

        }

        public IList<KonuListDTO> GetAll()
        {
            var konular = repo.GetAll();
            var konularDTO = mapper.Map<List<KonuListDTO>>(konular);
            return konularDTO;
        }

        public KonuListDTO GetById(int id)
        {
            var konu = repo.GetById(id);
            var konuListDTO= mapper.Map<KonuListDTO>(konu);
            return konuListDTO;
        }

        public bool Update(UpdateKonuDTO entity)
        {
            var konu = repo.GetById(entity.Id);
            konu = mapper.Map<Konu>(entity);
            if (konu is not null)
            {
                var result = repo.Update(konu);
                return result;
            }
            return false;
        }
    }
}
