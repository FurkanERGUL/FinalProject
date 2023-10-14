using FinalProject.BLL.DTOs.MakaleDTOs;
using FinalProject.BLL.Services.BaseServices;
using FinalProject.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Services.MakaleService
{
    public interface IMakaleService 
    {
        bool Add(CreateMakaleDTO entity);
        void Delete(MakaleListDTO entity);
        bool Update(UpdateMakaleDTO entity);
        bool Any(Expression<Func<Makale, bool>> filter);
        IList<MakaleListDTO> GetAll();
        MakaleDTO GetById(int id);
    }
}
