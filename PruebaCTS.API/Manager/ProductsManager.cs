using Dapper;
using PruebaCTS.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PruebaCTS.API.Manager
{
    public class ProductsManager
    {
        private string ConnectionString;

        public ProductsManager(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public async Task<bool> DeleteProducts(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE Products WHERE Id = @Id";

            var result = await db.ExecuteAsync(sql.ToString(), new { id });

            return result > 0;
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            var db = dbConnection();
            var sql = @"SELECT Id, Name, Description, Price FROM Products";

            return await db.QueryAsync<Products>(sql.ToString(), new { });
        }

        public async Task<Products> GetProductsDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT Id, Name, Description, Price FROM Products WHERE Id = @Id";

            return await db.QueryFirstOrDefaultAsync<Products>(sql.ToString(), new { Id = id });
        }

        public async Task<bool> InsertProduct(Products product)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Products (Name, Description, Price) VALUES (@Name, @Description, @Price)";

            var result = await db.ExecuteAsync(sql.ToString(), new { product.Name, product.Description, product.Price });

            return result > 0;
        }

        public async Task<bool> UpdateProducts(Products products)
        {
            var db = dbConnection();
            var sql = @"UPDATE Products SET Name = @Name, Description = @Description, Price = @Price WHERE Id = @Id";

            var result = await db.ExecuteAsync(sql.ToString(), new { products.Name, products.Description, products.Price, products.Id });

            return result > 0;
        }

        public async Task<IEnumerable<Purchase>> GetAllShopping()
        {
            var db = dbConnection();
            var sql = @"SELECT 0 Id, 0 Amount, Id IdProduct, Name NameProduct, Description DescriptionProduct, Price PriceProduct FROM Products";

            return await db.QueryAsync<Purchase>(sql.ToString(), new { });
        }

        public async Task<bool> Buy(IEnumerable<Purchase> purchases)
        {
            int ret = 0;
            var db = dbConnection();
            var sql = @"INSERT INTO Purchase (IdProduct, Amount) VALUES (@IdProduct, @Amount)";

            foreach (var purchase in purchases)
            {
                ret = await db.ExecuteAsync(sql.ToString(), new { purchase.IdProduct, purchase.Amount });
            }

            return ret > 0;
        }

        public async Task<IEnumerable<Purchase>> GetTopSales()
        {
            var db = dbConnection();
            var sql = @"SELECT 0 Id, SUM(Amount) Amount, IdProduct, Name NameProduct, Description DescriptionProduct, SUM(Price) PriceProduct 
                        FROM Products, Purchase 
                        WHERE Products.Id = Purchase.IdProduct 
                        GROUP BY IdProduct, Name, Description 
                        ORDER BY SUM(Amount) desc, SUM(Price) desc";

            return await db.QueryAsync<Purchase>(sql.ToString(), new { });
        }
    }
}
