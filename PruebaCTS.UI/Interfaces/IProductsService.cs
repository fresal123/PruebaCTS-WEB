using PruebaCTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCTS.UI.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<Products>> GetAllProducts();
        Task<Products> GetDetails(int id);
        Task<bool> DeleteProducts(int id);
        Task<bool> SaveProducts(Products products);
        Task<IEnumerable<Purchase>> GetAllShopping();
        Task<bool> Buy(IEnumerable<Purchase> purchases);

        Task<IEnumerable<Purchase>> GetTopSales();
    }
}
