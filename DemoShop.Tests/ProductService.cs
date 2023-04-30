using CoolEvents.Models.DTOs;
using System;

namespace CoolEvents.Tests
{
    internal class ProductService
    {
        private ShopDbContext context;

        public ProductService(ShopDbContext context)
        {
            this.context = context;
        }

        internal void Create(Product product, User user)
        {
            throw new NotImplementedException();
        }

        internal void Delete(int v)
        {
            throw new NotImplementedException();
        }

        internal void Edit(Product editProduct)
        {
            throw new NotImplementedException();
        }

        internal Product GetById(int v)
        {
            throw new NotImplementedException();
        }

        internal System.Collections.Generic.List<ProductDTO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}