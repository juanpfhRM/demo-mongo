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
            try
            {
                await _mongoService.TestConnectionAsync();
                return Ok(new { status = "OK", message = "Conexión exitosa a MongoDB." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "Error", message = ex.Message });
            }
        }

        // [HttpGet("products")]
        // public async Task<IActionResult> GetProducts()
        // {
        //     var products = await _mongoService.GetProductsAsync();
        //     return Ok(products);
        // }
    }
}