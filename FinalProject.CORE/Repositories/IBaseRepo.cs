using FinalProject.CORE.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.CORE.Repositories
{
    public interface IBaseRepo<T> where T : class, IBaseEntity
    {
        bool Add(T entity);
        void Delete(T entity);
        bool Update(T entity);
        IList<T> GetAll();
        bool Any(Expression<Func<T, bool>> filter);
    }
}
