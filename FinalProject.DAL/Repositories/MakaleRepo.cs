using FinalProject.CORE.Concrete;
using FinalProject.CORE.Repositories;
using FinalProject.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Repositories
{
    public class MakaleRepo : BaseRepo<Makale>, IMakaleRepo
    {
        private readonly AppDbContext dbContext;
        public MakaleRepo(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Makale GetById(int id)
        {
            var makale = dbContext.Makales.Find(id);
            return makale;
        }
    }
}
