using FinalProject.CORE.Abstract;
using FinalProject.CORE.Repositories;
using FinalProject.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Repositories
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class, IBaseEntity
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<T> table;
        public BaseRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.table = dbContext.Set<T>();
        }

        public bool Add(T entity)
        {
            table.Add(entity);
            if (dbContext.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return table.Any(filter);
        }

        public void Delete(T entity)
        {
            if (entity!=null)
            {
                table.Remove(entity);
            }
            
        }

        public IList<T> GetAll()
        {
            var list = table.ToList();
            if(list is not null)
                return list;
            throw new Exception("Liste boş");

        }

        public bool Update(T entity)
        {
            if (entity is not null)
            {
                entity.Status = CORE.Enums.Status.Modified;
                table.Update(entity);
                return true;
            }
            return false;
        }
    }
}