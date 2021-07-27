using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasivianPrueba.Core.Interface.Repository
{
    public interface IRepository<T> where T: class
    {
        T Create(T entity);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task<List<T>> AddRange(List<T> Listentity, CancellationToken cancellationToken = default);
        Task UpdateRange(List<T> Listentity, CancellationToken cancellationToken = default);
        T GetById(int id);
        IQueryable<T> GetAll();
    }
}
