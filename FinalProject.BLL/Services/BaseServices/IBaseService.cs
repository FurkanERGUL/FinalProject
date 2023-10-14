using FinalProject.CORE.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Services.BaseServices
{
    public interface IBaseService<T> where T : class, IBaseEntity
    {
        bool Add(T entity);
        void Delete(T entity);
        bool Update(T entity);
        bool Any(Expression<Func<T, bool>> filter);
        IList<T> GetAll();
    }
}
