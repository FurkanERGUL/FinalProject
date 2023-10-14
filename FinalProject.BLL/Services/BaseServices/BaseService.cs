using FinalProject.CORE.Abstract;
using FinalProject.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Services.BaseServices
{
    public class BaseService<T> : IBaseService<T> where T : class, IBaseEntity
    {
        private readonly IBaseRepo<T> _repo;

        public BaseService(IBaseRepo<T> repo)
        {
            _repo = repo;
        }

        public bool Add(T entity)
        {
            return _repo.Add(entity);
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return _repo.Any(filter);
        }

        public void Delete(T entity)
        {
            _repo.Delete(entity);
        }

        public IList<T> GetAll()
        {
            return _repo.GetAll();
        }

        public bool Update(T entity)
        {
            return _repo.Update(entity);
        }
    }
}
