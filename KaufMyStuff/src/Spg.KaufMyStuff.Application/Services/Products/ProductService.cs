using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.Application.Services.Products
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create()
        {
            
        }

        public IQueryable<Product> GetAll()
        {
            return null;
        }
    }
}
