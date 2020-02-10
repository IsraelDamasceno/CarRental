using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class 
    {
        Task<T> InsertAsync(T item);
        Task Update(T item);
        Task DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
    }
}
