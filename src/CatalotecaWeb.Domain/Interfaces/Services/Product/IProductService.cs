using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalotecaWeb.Domain.Entities;

namespace CatalotecaWeb.Domain.Interfaces.Services.Product
{
    public interface IProductService
    {
        Task<ProductEntity> Get(Guid id);
        Task<IEnumerable<ProductEntity>> GetAll();
        Task<ProductEntity> Post(ProductEntity product);
        Task<ProductEntity> Put(ProductEntity product);
        Task<bool> Delete(Guid id);
    }
}
