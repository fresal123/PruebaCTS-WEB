using PruebaCTS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCTS.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllProducts();
        Task<Products> GetProductsDetails(int id);
        Task<bool> InsertProduct(Products product);
        Task<bool> UpdateProducts(Products products);
        Task<bool> DeleteProducts(int id);
        Task<IEnumerable<Purchase>> GetAllShopping();
        Task<bool> Buy(IEnumerable<Purchase> purchases);
        Task<IEnumerable<Purchase>> GetTopSales();
    }
}
