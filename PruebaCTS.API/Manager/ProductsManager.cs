using Dapper;
using PruebaCTS.Data.Logger;
using PruebaCTS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PruebaCTS.API.Manager
{
    public class ProductsManager
    {
        private string ConnectionString;
        private Logs _logs;

        public ProductsManager(string connectionString)
        {
            ConnectionString = connectionString;
            _logs = new Logs();
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public async Task<bool> DeleteProducts(int id)
        {
            try
            {
                var db = dbConnection();
                var sql = @"DELETE Products WHERE Id = @Id";

                var result = await db.ExecuteAsync(sql.ToString(), new { id });

                return result > 0;
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: DeleteProducts. Clase: ProductsManager");
                _logs.Add(ex.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            try
            {
                var db = dbConnection();
                var sql = @"SELECT Id, Name, Description, Price FROM Products";

                return await db.QueryAsync<Products>(sql.ToString(), new { });
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetAllProducts. Clase: ProductsManager");
                _logs.Add(ex.Message);
                throw ex;
            }
           
        }

        public async Task<Products> GetProductsDetails(int id)
        {
            try
            {
                var db = dbConnection();
                var sql = @"SELECT Id, Name, Description, Price FROM Products WHERE Id = @Id";

                return await db.QueryFirstOrDefaultAsync<Products>(sql.ToString(), new { Id = id });
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetProductsDetails. Clase: ProductsManager");
                _logs.Add(ex.Message);
                throw ex;
            }
            
        }

        public async Task<bool> InsertProduct(Products product)
        {
            try
            {
                var db = dbConnection();
                var sql = @"INSERT INTO Products (Name, Description, Price) VALUES (@Name, @Description, @Price)";

                var result = await db.ExecuteAsync(sql.ToString(), new { product.Name, product.Description, product.Price });

                return result > 0;
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: InsertProduct. Clase: ProductsManager");
                _logs.Add(ex.Message);
                throw ex;
            }
        }

        public async Task<bool> UpdateProducts(Products products)
        {
            try
            {
                var db = dbConnection();
                var sql = @"UPDATE Products SET Name = @Name, Description = @Description, Price = @Price WHERE Id = @Id";

                var result = await db.ExecuteAsync(sql.ToString(), new { products.Name, products.Description, products.Price, products.Id });

                return result > 0;
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: UpdateProducts. Clase: ProductsManager");
                _logs.Add(ex.Message);
                throw ex;
            }
            
        }

        public async Task<IEnumerable<Purchase>> GetAllShopping()
        {
            try
            {
                var db = dbConnection();
                var sql = @"SELECT 0 Id, 0 Amount, Id IdProduct, Name NameProduct, Description DescriptionProduct, Price PriceProduct FROM Products";

                return await db.QueryAsync<Purchase>(sql.ToString(), new { });
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetAllShopping. Clase: ProductsManager");
                _logs.Add(ex.Message);
                throw ex;
            }
           
        }

        public async Task<bool> Buy(IEnumerable<Purchase> purchases)
        {
            try
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
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: Buy. Clase: ProductsManager");
                _logs.Add(ex.Message);
                throw ex;
            }
            
        }

        public async Task<IEnumerable<Purchase>> GetTopSales()
        {
            try
            {
                var db = dbConnection();
                var sql = @"SELECT 0 Id, SUM(Amount) Amount, IdProduct, Name NameProduct, Description DescriptionProduct, SUM(Price) PriceProduct 
                        FROM Products, Purchase 
                        WHERE Products.Id = Purchase.IdProduct 
                        GROUP BY IdProduct, Name, Description 
                        ORDER BY SUM(Amount) desc, SUM(Price) desc";

                return await db.QueryAsync<Purchase>(sql.ToString(), new { });
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetTopSales. Clase: ProductsManager");
                _logs.Add(ex.Message);
                throw ex;
            }
        }
    }
}
