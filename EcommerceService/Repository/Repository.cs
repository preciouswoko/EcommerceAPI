using EcommerceData.Data;
using EcommerceData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly EcommerceDbContext _dbContext;

        public Repository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public  IEnumerable<T> GetAll()
        {
           return   _dbContext.Set<T>();

        }
        public async Task<T> GetbyID(int id)
        {  
            return  _dbContext.Set<T>().Find(id);   

        }
        public async void Add(T entity)
        {
            await _dbContext.AddAsync(entity);
             _dbContext.SaveChanges();
        }
        public  void Update(T entity)
        {
            var f =_dbContext.Update(entity);
           _dbContext.SaveChanges();
        }

        public async Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return  _dbContext.Set<T>().Where(expression).ToList();

        }

        public void Delete(T entity)
        {
            
            var f =_dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
