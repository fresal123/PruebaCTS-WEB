using PruebaCTS.Data.Logger;
using PruebaCTS.Data.Repositories;
using PruebaCTS.Model;
using PruebaCTS.UI.Data;
using PruebaCTS.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaCTS.UI.Services
{
    public class ProductsService : IProductsService
    {
        private readonly SqlConfiguration _configuration;
        private IProductRepository _productRepository;
        private Logs _logs;

        public ProductsService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _productRepository = new ProductRepository(configuration.ConnectionString);
            _logs = new Logs();
        }

        public Task<bool> DeleteProducts(int id)
        {
            try
            {
                return _productRepository.DeleteProducts(id);
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: DeleteProducts. Clase: ProducsServices");
                _logs.Add(ex.Message);
                throw ex;
            }
        }

        public Task<IEnumerable<Products>> GetAllProducts()
        {
            try
            {
                return _productRepository.GetAllProducts();
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetAllProducts. Clase: ProducsServices");
                _logs.Add(ex.Message);
                throw ex;
            }
        }

        public Task<Products> GetDetails(int id)
        {
            try
            {
                return _productRepository.GetProductsDetails(id);
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetDetails. Clase: ProducsServices");
                _logs.Add(ex.Message);
                throw ex;
            }
            
        }

        public Task<bool> SaveProducts(Products products)
        {
            try
            {
                if (products.Id == 0)
                    return _productRepository.InsertProduct(products);
                else
                    return _productRepository.UpdateProducts(products);
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: SaveProducts. Clase: ProducsServices");
                _logs.Add(ex.Message);
                throw ex;
            }
        }

        public Task<IEnumerable<Purchase>> GetAllShopping()
        {
            try
            {
                return _productRepository.GetAllShopping();
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetAllShopping. Clase: ProducsServices");
                _logs.Add(ex.Message);
                throw ex;
            }
        }

        public Task<bool> Buy(IEnumerable<Purchase> purchases)
        {
            try
            {
                return _productRepository.Buy(purchases);
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: Buy. Clase: ProducsServices");
                _logs.Add(ex.Message);
                throw ex;
            }
        }

        public Task<IEnumerable<Purchase>> GetTopSales()
        {
            try
            {
                return _productRepository.GetTopSales();
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetTopSales. Clase: ProducsServices");
                _logs.Add(ex.Message);
                throw ex;
            }
        }
    }
}
