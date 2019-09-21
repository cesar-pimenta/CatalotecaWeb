using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalotecaWeb.Domain.Entities;
using CatalotecaWeb.Domain.Interfaces;
using CatalotecaWeb.Domain.Interfaces.Services.Product;

namespace CatalotecaWeb.Service.Services
{
    public class ProductService : IProductService
    {
        private IRepository<ProductEntity> _repository;
        public ProductService(IRepository<ProductEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ProductEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<ProductEntity> Post(ProductEntity product)
        {
            return await _repository.InsertAsync(product);
        }

        public async Task<ProductEntity> Put(ProductEntity product)
        {
            return await _repository.UpdateAsync(product);
        }
    }
}
