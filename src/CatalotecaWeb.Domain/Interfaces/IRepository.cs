using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalotecaWeb.Domain.Entities;

namespace CatalotecaWeb.Domain.Interfaces
{
    // T é uma referencia a TABLE, mas pode ser qualquer Letra ou palavra. 
    public interface IRepository<T>
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
    }
}
