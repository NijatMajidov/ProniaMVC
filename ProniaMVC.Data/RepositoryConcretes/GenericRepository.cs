using ProniaMVC.Core.Models;
using ProniaMVC.Core.RepositoryAbstracts;
using ProniaMVC.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Data.RepositoryConcretes
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity,new()
    {
        private readonly AppDbContext _dbContext;
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public T Get(Func<T, bool>? func = null)
        {
            return func == null ?
                _dbContext.Set<T>().FirstOrDefault() :
                _dbContext.Set<T>().FirstOrDefault(func);
        }

        public List<T> GetAll(Func<T, bool>? func = null)
        {
            return func == null ?
                _dbContext.Set<T>().ToList() :
                _dbContext.Set<T>().Where(func).ToList();
        }
    }
}
