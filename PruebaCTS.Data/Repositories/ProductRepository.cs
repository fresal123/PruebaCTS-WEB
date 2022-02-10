using Dapper;
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
        
        public ProductRepository(string connectionString)
        {
            ConnectionString = connectionString;
            _uri = "https://localhost:44348/api/Products/";
        }

        protected SqlConnection dbConnection() 
        {
            return new SqlConnection(ConnectionString);
        }

        public async Task<bool> DeleteProducts(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.DeleteAsync($"{_uri}DeleteProducts/?id={id}");
                return result.StatusCode > 0;
            }
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync($"{_uri}GetAllProducts");
                var resultString = await result.Content.ReadAsStringAsync();
                var productsList = JsonSerializer.Deserialize<IEnumerable<Products>>(resultString, jsonSerializerOptions);
                return productsList;
            }
        }

        public async Task<Products> GetProductsDetails(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync($"{_uri}GetProductsDetails/?id={id}");
                var resultString = await result.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<Products>(resultString, jsonSerializerOptions);
                return product;
            }
        }

        public async Task<bool> InsertProduct(Products product)
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.PostAsJsonAsync($"{_uri}InsertProduct", product);
                return result.StatusCode > 0;
            }
        }

        public async Task<bool> UpdateProducts(Products products)
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.PutAsJsonAsync ($"{_uri}UpdateProducts", products);
                return result.StatusCode > 0;
            }
        }

        public async Task<IEnumerable<Purchase>> GetAllShopping()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync($"{_uri}GetAllShopping");
                var resultString = await result.Content.ReadAsStringAsync();
                var purchaseList = JsonSerializer.Deserialize<IEnumerable<Purchase>>(resultString, jsonSerializerOptions);
                return purchaseList;
            }
        }

        public async Task<bool> Buy(IEnumerable<Purchase> purchases)
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.PostAsJsonAsync($"{_uri}Buy", purchases);
                return result.StatusCode > 0;
            }
        }

        public async Task<IEnumerable<Purchase>> GetTopSales()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync($"{_uri}GetTopSales");
                var resultString = await result.Content.ReadAsStringAsync();
                var purchaseList = JsonSerializer.Deserialize<IEnumerable<Purchase>>(resultString, jsonSerializerOptions);
                return purchaseList;
            }
        }
    }
}