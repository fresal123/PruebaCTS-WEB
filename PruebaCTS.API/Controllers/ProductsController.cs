using Microsoft.AspNetCore.Mvc;
using PruebaCTS.API.Manager;
using PruebaCTS.Data.Logger;
using PruebaCTS.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaCTS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SqlConfiguration _configuration;
        ProductsManager manager;
        private Logs _logs;

        public ProductsController(SqlConfiguration configuration)
        {
            _configuration = configuration;
            manager = new ProductsManager(configuration.ConnectionString);
            _logs = new Logs();
        }

        /// <summary>
        /// Borrar producto
        /// </summary>
        /// <returns></returns>
        [HttpDelete("DeleteProducts")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Objeto nulo");
                }

                bool respuesta = await manager.DeleteProducts(id);

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: DeleteProducts. Clase: ProducsController");
                _logs.Add(ex.Message);
                return StatusCode(500, $"Ocurrio un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtener productos
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var resultado = await manager.GetAllProducts();

                if (resultado == null)
                {
                    return NotFound("No hay datos");
                }

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetAllProducts. Clase: ProducsController");
                _logs.Add(ex.Message);
                return StatusCode(500, $"Ocurrio un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtener producto por id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProductsDetails")]
        public async Task<IActionResult> GetProductsDetails(int id)
        {
            try
            {
                var resultado = await manager.GetProductsDetails(id);

                if (resultado == null)
                {
                    return NotFound("No hay datos");
                }

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetProductsDetails. Clase: ProducsController");
                _logs.Add(ex.Message);
                return StatusCode(500, $"Ocurrio un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Insertar producto
        /// </summary>
        /// <returns></returns>
        [HttpPost("InsertProduct")]
        public async Task<IActionResult> InsertProduct([FromBody] Products products)
        {
            try
            {
                if (products == null)
                {
                    return BadRequest("Objeto nulo");
                }

                var resultado = await manager.InsertProduct(products);

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: InsertProduct. Clase: ProducsController");
                _logs.Add(ex.Message);
                return StatusCode(500, $"Ocurrio un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualizar producto
        /// </summary>
        /// <returns></returns>
        [HttpPut("UpdateProducts")]
        public async Task<IActionResult> UpdateProducts([FromBody] Products products)
        {
            try
            {
                if (products == null)
                {
                    return BadRequest("Objeto nulo");
                }

                var resultado = await manager.UpdateProducts(products);

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: UpdateProducts. Clase: ProducsController");
                _logs.Add(ex.Message);
                return StatusCode(500, $"Ocurrio un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtener total ventas
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllShopping")]
        public async Task<IActionResult> GetAllShopping()
        {
            try
            {
                var resultado = await manager.GetAllShopping();

                if (resultado == null)
                {
                    return NotFound("No hay datos");
                }

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetAllShopping. Clase: ProducsController");
                _logs.Add(ex.Message);
                return StatusCode(500, $"Ocurrio un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Insertar Ventas
        /// </summary>
        /// <returns></returns>
        [HttpPost("Buy")]
        public async Task<IActionResult> Buy([FromBody] IEnumerable<Purchase> purchases)
        {
            try
            {
                if (purchases == null)
                {
                    return BadRequest("Objeto nulo");
                }

                var resultado = await manager.Buy(purchases);

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: Buy. Clase: ProducsController");
                _logs.Add(ex.Message);
                return StatusCode(500, $"Ocurrio un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtener top ventas
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTopSales")]
        public async Task<IActionResult> GetTopSales()
        {
            try
            {
                var resultado = await manager.GetTopSales();

                if (resultado == null)
                {
                    return NotFound("No hay datos");
                }

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                _logs.Add("Error en metodo: GetTopSales. Clase: ProducsController");
                _logs.Add(ex.Message);
                return StatusCode(500, $"Ocurrio un error: {ex.Message}");
            }
        }
    }
}
