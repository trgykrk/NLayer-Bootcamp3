using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Data;
using NLayer.Service;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAll();
            return new ObjectResult(response) { StatusCode=response.Status };
        }

        [HttpGet("GetProductFull")]
        public async Task<IActionResult> GetProductFull()
        {
            var response = await _productService.GetProductFullModel();
            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpGet("GetProductView")]
        public async Task<IActionResult> GetProductView()
        {
            var response = await _productService.GetProductViewModel();
            return new ObjectResult(response) { StatusCode = response.Status };
        }
    }
}
