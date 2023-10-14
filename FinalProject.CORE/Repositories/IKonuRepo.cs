using FinalProject.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.CORE.Repositories
{
    public interface IKonuRepo : IBaseRepo<Konu>
    {
        Konu GetById(int id);
    }
}
