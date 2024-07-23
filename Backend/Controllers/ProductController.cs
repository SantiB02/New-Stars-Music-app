using Merchanmusic.Data.Entities;
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
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public ProductController(IProductService productService, IUserService userService, ITokenService tokenService)
        {
            _productService = productService;
            _userService = userService;
            _tokenService = tokenService;
            
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetProducts()
        {
            try
            {
                List<Product> products = _productService.GetProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpGet("featured")]
        public IActionResult GetFeaturedProducts([FromQuery] int minimumSales)
        {
            if (minimumSales <= 0)
            {
                return BadRequest("Minimum sales must be greater than 0");
            }
            try
            {
                List<Product> featuredProducts = _productService.GetFeaturedProducts(minimumSales);
                if (featuredProducts.Count > 0)
                {
                    return Ok(featuredProducts);
                } else
                {
                    return NotFound("No product meets the minimum sales criteria");
                }
            } catch (Exception ex)
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
            string subClaim = _tokenService.GetUserId();
            string role = _userService.GetRoleById(subClaim);
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

        [HttpGet("by-seller")]
        public IActionResult GetProductBySeller()
        {
            string sellerId = _tokenService.GetUserId();
            string role = _userService.GetRoleById(sellerId);
            if (role == "Seller")
            {
                var product = _productService.GetProductBySeller(sellerId);

                if (product == null)
                {
                    return NotFound($"No hay productos");
                }

                return Ok(product);
            }
            return Forbid();
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductCreateDto productDto)
        {
            string subClaim = _tokenService.GetUserId();
            string role = _userService.GetRoleById(subClaim);

            if (role == "Admin" || role == "Seller")
            {
                if (productDto.Name == null || productDto.Price <= 0)
                {
                    return BadRequest("Product can't be created because of incorrect or empty fields");
                }
                try
                {
                    var product = new Product()
                    {
                        Name = productDto.Name,
                        Description = productDto.Description,
                        Price = productDto.Price,
                        Stock = productDto.Stock,
                        ArtistOrBand = productDto.ArtistOrBand,
                        SellerId = subClaim,
                        Code = productDto.Code,
                        ImageLink = productDto.ImageLink,
                        CategoryId = productDto.CategoryId,
                    };

                    Product createdProduct = _productService.CreateProduct(product);

                    return Ok(createdProduct);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }

        [HttpPut("buy")]
        public IActionResult BuyProducts([FromBody] List<ProductBuyOrder> productBuyOrders)
        {
            bool? productsBought = _productService.BuyProducts(productBuyOrders);
            if (productsBought == true)
            {
                return Ok("Products were bought successfully");
            } else if (productsBought == false)
            {
                return BadRequest("One or more products don't have enough stock");
            } else
            {
                return BadRequest("Empty products list or one or more products don't exist");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            string subClaim = _tokenService.GetUserId();
            string role = _userService.GetRoleById(subClaim);
            if (role == "Admin" || role == "Seller")
            {
                try
                {
                    var existingProduct = _productService.GetProductById(id);

                    if (existingProduct == null)
                    {
                        return NotFound($"No product found with ID: {id}");
                    }

                    _productService.DeleteProduct(id, subClaim);
                    return Ok($"Product with ID: {id} was successfully deleted");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }

        [HttpPut("restore/{id}")]
        public IActionResult RestoreProduct([FromRoute] int id)
        {
            string subClaim = _tokenService.GetUserId();
            string role = _userService.GetRoleById(subClaim);
            if (role == "Seller")
            {
                try
                {
                    var existingProduct = _productService.GetProductById(id);

                    if (existingProduct == null)
                    {
                        return NotFound($"No product found with ID: {id}");
                    }

                    _productService.RestoreProduct(id, subClaim);
                    return Ok($"Product with ID: {id} was successfully restored");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            } else
            {
                return Forbid();
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            string subClaim = _tokenService.GetUserId();
            string role = _userService.GetRoleById(subClaim);
            if (role == "Admin" || role == "Seller")
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest(new { error = "No file uploaded" });
                }
                try
                {
                    var url = await _productService.UploadImageAsync(file);
                    return Ok(new { url });
                }
                catch (System.Exception ex)
                {
                    return StatusCode(500, new { error = ex.Message });
                }
            }
            return Forbid();
           
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
                try
                {
                    var url = await _productService.GetCategoriesAsync();
                    return Ok(new { url });
                }
                catch (System.Exception ex)
                {
                    return StatusCode(500, new { error = ex.Message });
                }
            
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductUpdateDto productUpdateDto)
        {
            string subClaim = _tokenService.GetUserId();
            string role = _userService.GetRoleById(subClaim);
            if (role == "Seller")
            {
                try
                {
                    _productService.UpdateProduct(productUpdateDto, subClaim);
                    return Ok($"Product updated successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error updating product: {ex.Message} - {ex.InnerException}");
                }
            }
            return Forbid();
        }
    }
}
