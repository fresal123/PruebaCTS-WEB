using Microsoft.AspNetCore.Mvc;
using PruebaCTS.API.Controllers;
using PruebaCTS.API.Manager;
using PruebaCTS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PruebaCTS.Test
{
    public class ProductsTest
    {
        private readonly ProductsController productsController;
        private readonly SqlConfiguration _configuration;

        public ProductsTest()
        {
            _configuration = new SqlConfiguration("Data Source = SERCO5CG9263FSC\\SQLEXPRESS; Initial Catalog = Pruebas; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            productsController = new ProductsController(_configuration);
        }

        [Fact]
        public void InsertProductTest()
        {
            Products products = new Products() { Name="NameTEST", Description="DescriptionTEST", Price=500};

            var result = productsController.InsertProduct(products);
            Assert.True(result != null);
        }

        [Fact]
        public void DeleteProductsTest()
        {
            int id = 1;

            var result = productsController.DeleteProducts(id);
            Assert.True(result != null);
        }

        [Fact]
        public void UpdateProductsTest()
        {
            Products products = new Products() { Name = "NameTEST", Description = "DescriptionTEST", Price = 500 };

            var result = productsController.UpdateProducts(products);
            Assert.True(result != null);
        }

        [Fact]
        public void BuyTest()
        {
            List<Purchase> purchases = new List<Purchase>();
            Purchase purchase = new Purchase() { IdProduct=1, Amount=2 };
            purchases.Add(purchase);

            var result = productsController.Buy(purchases);
            Assert.True(result != null);
        }
    }
}