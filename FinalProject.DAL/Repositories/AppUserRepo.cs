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
    public class AppUserRepo : BaseRepo<AppUser>, IAppUserRepo
    {
        public AppUserRepo(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
