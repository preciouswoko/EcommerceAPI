using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<T> GetbyID(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetBySingleCondition(Expression<Func<T, bool>> expression);
        Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression);
    }
}
