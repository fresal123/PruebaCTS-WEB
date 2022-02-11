using Dapper;
using PruebaCTS.Data.Logger;
using PruebaCTS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PruebaCTS.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private string ConnectionString;
        private string _uri;
        private JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        private Logs _logs;

        public ProductRepository(string connectionString)
        {
            ConnectionString = connectionString;
            _uri = "https://localhost:44348/api/Products/";
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
                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.DeleteAsync($"{_uri}DeleteProducts/?id={id}");
                    return result.StatusCode > 0;
                }
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: DeleteProducts. Clase: ProducsRepository");
                _logs.Add(ex.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.GetAsync($"{_uri}GetAllProducts");
                    var resultString = await result.Content.ReadAsStringAsync();
                    var productsList = JsonSerializer.Deserialize<IEnumerable<Products>>(resultString, jsonSerializerOptions);
                    return productsList;
                }
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetAllProducts. Clase: ProducsRepository");
                _logs.Add(ex.Message);
                throw ex;
            }
        }

        public async Task<Products> GetProductsDetails(int id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.GetAsync($"{_uri}GetProductsDetails/?id={id}");
                    var resultString = await result.Content.ReadAsStringAsync();
                    var product = JsonSerializer.Deserialize<Products>(resultString, jsonSerializerOptions);
                    return product;
                }
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetProductsDetails. Clase: ProducsRepository");
                _logs.Add(ex.Message);
                throw ex;
            }
        }

        public async Task<bool> InsertProduct(Products product)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.PostAsJsonAsync($"{_uri}InsertProduct", product);
                    return result.StatusCode > 0;
                }
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: InsertProduct. Clase: ProducsRepository");
                _logs.Add(ex.Message);
                throw ex;
            }
        }

        public async Task<bool> UpdateProducts(Products products)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.PutAsJsonAsync($"{_uri}UpdateProducts", products);
                    return result.StatusCode > 0;
                }
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: UpdateProducts. Clase: ProducsRepository");
                _logs.Add(ex.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<Purchase>> GetAllShopping()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.GetAsync($"{_uri}GetAllShopping");
                    var resultString = await result.Content.ReadAsStringAsync();
                    var purchaseList = JsonSerializer.Deserialize<IEnumerable<Purchase>>(resultString, jsonSerializerOptions);
                    return purchaseList;
                }
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetAllShopping. Clase: ProducsRepository");
                _logs.Add(ex.Message);
                throw ex;
            }
           
        }

        public async Task<bool> Buy(IEnumerable<Purchase> purchases)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.PostAsJsonAsync($"{_uri}Buy", purchases);
                    return result.StatusCode > 0;
                }
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: Buy. Clase: ProducsRepository");
                _logs.Add(ex.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<Purchase>> GetTopSales()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.GetAsync($"{_uri}GetTopSales");
                    var resultString = await result.Content.ReadAsStringAsync();
                    var purchaseList = JsonSerializer.Deserialize<IEnumerable<Purchase>>(resultString, jsonSerializerOptions);
                    return purchaseList;
                }
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetTopSales. Clase: ProducsRepository");
                _logs.Add(ex.Message);
                throw ex;
            }
        }
    }
}