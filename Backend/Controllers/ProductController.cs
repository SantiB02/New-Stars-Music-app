using Merchanmusic.Data.Entities.Products;
using Merchanmusic.Data.Models;
using Merchanmusic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Merchanmusic.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetProducts()
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

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
                var product = _productService.GetProductById(id);

                if (product == null)
                {
                    return NotFound($"El producto con el ID: {id} no fue encontrado");
                }

                return Ok(product);
        }


        [HttpGet("by-name/{name}")]
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


        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductCreatDto productDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                if (productDto.Name == null || productDto.Price <= 0)
                {
                    return BadRequest("Producto no creado, por favor completar los campos");
                }
                try
                {
                    var product = new Product()
                    {
                        Name = productDto.Name,
                        Price = productDto.Price,
                        Stock = productDto.Stock
                    };

                    int id = _productService.CreateProduct(product);

                    return Ok($"Producto creado exitosamente con id: {id}");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }

        [HttpDelete]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                try
                {
                    var existingProduct = _productService.GetProductById(id);

                    if (existingProduct == null)
                    {
                        return NotFound($"No se encontró ningún producto con el ID: {id}");
                    }

                    _productService.DeleteProduct(id);
                    return Ok($"Producto con ID: {id} eliminado");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] ProductUpdateDto product)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                var productToUpdate = _productService.GetProductById(id);
                if (productToUpdate == null)
                {
                    return NotFound($"Producto con ID {id} no encontrado");
                }
                if (product.Price == 0 || product.Stock == 0)
                {
                    return BadRequest("Producto no actualizado, por favor completar los campos");
                }

                try
                {
                    productToUpdate.Price = product.Price;
                    productToUpdate.Stock = product.Stock;

                    productToUpdate = _productService.UpdateProduct(productToUpdate);
                    return Ok($"Producto actualizado exitosamente");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error al actualizar el producto: {ex.Message}");
                }
            }
            return Forbid();
        }

    }
}
