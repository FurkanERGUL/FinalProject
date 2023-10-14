using FinalProject.BLL.DTOs.KonuDTOs;
using FinalProject.BLL.DTOs.MakaleDTOs;
using FinalProject.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Services.KonuService
{
    public interface IKonuService
    {
        bool Add(CreateKonuDTO entity);
        void Delete(KonuListDTO entity);
        bool Update(UpdateKonuDTO entity);
        bool Any(Expression<Func<Konu, bool>> filter);
        IList<KonuListDTO> GetAll();
        KonuListDTO GetById(int id);
    }
}
