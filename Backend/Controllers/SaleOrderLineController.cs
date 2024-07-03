using Merchanmusic.Data.Entities;
using Merchanmusic.Services.Implementations;
using Merchanmusic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Merchanmusic.Controllers
{
    [Route("api/sale-order-lines")]
    [ApiController]
    public class SaleOrderLineController : ControllerBase
    {
        private readonly ISaleOrderLineService _solService;
        private readonly IUserService _userService;

        public SaleOrderLineController(ISaleOrderLineService solService, IUserService userService)
        {
            _solService = solService;
            _userService = userService;
        }

        [HttpGet("{saleOrderId}")]
        public IActionResult GetAllBySaleOrder([FromRoute] int saleOrderId)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string role = _userService.GetRoleById(subClaim);
            if (role == "Admin")
            {
                try
                {
                    var sol = _solService.GetAllBySaleOrder(saleOrderId);
                    if (sol.Count == 0)
                    {
                        return NotFound("Líneas de venta no encontradas");
                    }
                    return Ok(sol);

                }
                catch (Exception ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            }
            return Forbid();
        }

        [HttpGet("by-product/{productId}")]
        public IActionResult GetAllByProduct([FromRoute] int productId)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string role = _userService.GetRoleById(subClaim);
            if (role == "Admin")
            {
                try
                {
                    var sol = _solService.GetAllByProduct(productId);
                    if (sol.Count == 0)
                    {
                        return NotFound("Líneas de venta no encontradas");
                    }
                    return Ok(sol);

                }
                catch (Exception ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            }
            return Forbid();
        }
    }
}
