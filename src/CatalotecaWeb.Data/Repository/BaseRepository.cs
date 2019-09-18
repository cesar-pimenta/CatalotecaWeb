using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalotecaWeb.Data.Context;
using CatalotecaWeb.Domain.Entities;
using CatalotecaWeb.Domain.Interfaces;

namespace CatalotecaWeb.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        public BaseRepository(MyContext context)
        {
            
        }
        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> InterAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T> SelectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
