using FinalProject.CORE.Abstract;
using FinalProject.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.CORE.Repositories
{
    public interface IMakaleRepo : IBaseRepo<Makale>
    {
        Makale GetById(int id);
    }
}
