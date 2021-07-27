using MasivianPrueba.Core.Entitiy;
using MasivianPrueba.Core.Interface.Repository;
using MasivianPrueba.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MasivianPrueba.Infraestructure.Repository
{
    public  class Repository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly AppDbContext _dbContext;
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public  T Create(T entity)
        {            
             _dbContext.Set<T>().Add(entity);
             _dbContext.SaveChanges();          
            
            return entity;
        }
        public async Task<List<T>> AddRange(List<T> Listentity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<T>().AddRangeAsync(Listentity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Listentity;
        }
        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }
        public void SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
        }
        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateRange(List<T> Listentity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().UpdateRange(Listentity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
