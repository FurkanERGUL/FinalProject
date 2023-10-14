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
    public class KonuRepo : BaseRepo<Konu>, IKonuRepo
    {
        private readonly AppDbContext dbContext;
        public KonuRepo(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Konu GetById(int id)
        {
            return dbContext.Konus.Find(id);
        }
    }
}
