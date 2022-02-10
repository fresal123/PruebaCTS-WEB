using PruebaCTS.Data.Repositories;
using PruebaCTS.Model;
using PruebaCTS.UI.Data;
using PruebaCTS.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCTS.UI.Services
{
    public class ProductsService : IProductsService
    {
        private readonly SqlConfiguration _configuration;
        private IProductRepository _productRepository;

        public ProductsService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _productRepository = new ProductRepository(configuration.ConnectionString);
        }

        public Task<bool> DeleteProducts(int id)
        {
            return _productRepository.DeleteProducts(id);
        }

        public Task<IEnumerable<Products>> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Task<Products> GetDetails(int id)
        {
            return _productRepository.GetProductsDetails(id);
        }

        public Task<bool> SaveProducts(Products products)
        {
            if (products.Id == 0)
                return _productRepository.InsertProduct(products);
            else
                return _productRepository.UpdateProducts(products);
        }

        public Task<IEnumerable<Purchase>> GetAllShopping()
        {
            return _productRepository.GetAllShopping();
        }

        public Task<bool> Buy(IEnumerable<Purchase> purchases)
        {
            return _productRepository.Buy(purchases);
        }

        public Task<IEnumerable<Purchase>> GetTopSales()
        {
            return _productRepository.GetTopSales();
        }
    }
}
