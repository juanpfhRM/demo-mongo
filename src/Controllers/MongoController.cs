using Microsoft.AspNetCore.Mvc;
using ApiMongoDemo.Services;

namespace ApiMongoDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MongoController : ControllerBase
    {
        private readonly MongoService _mongoService;

        public MongoController(MongoService mongoService)
        {
            _mongoService = mongoService;
        }

        [HttpGet("test")]
        public async Task<IActionResult> TestConnection()
        {
            var isConnected = await _mongoService.TestConnectionAsync();

            if (isConnected)
                return Ok(new { status = "OK", message = "Conexión exitosa a MongoDB" });
            else
                return StatusCode(500, new { status = "Error", message = "No se pudo conectar a MongoDB" });
        }

        // [HttpGet("products")]
        // public async Task<IActionResult> GetProducts()
        // {
        //     var products = await _mongoService.GetProductsAsync();
        //     return Ok(products);
        // }
    }
}