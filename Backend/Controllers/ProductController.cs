using Merchanmusic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Merchanmusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetProducts()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin" || role == "Client")
            {
                var products = _productService.GetProducts();
                try
                {
                    return Ok(products);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }

        [HttpGet("GetProductById{id}")]
        public IActionResult GetProductById(int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                var product = _productService.GetProductById(id);

                if (product == null)
                {
                    return NotFound($"El producto con el ID: {id} no fue encontrado");
                }

                return Ok(product);
            }
            return Forbid();
        }

        [HttpGet("GetProductByName{name}")]
        public IActionResult GetProductByName(string name)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin" || role == "Client")
            {
                var product = _productService.GetProductByName(name);

                if (product == null)
                {
                    return NotFound($"El producto no fue encontrado");
                }

                return Ok(product);
            }
            return Forbid();
        }

    }
}
