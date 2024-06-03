using Merchanmusic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Merchanmusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleOrderLineController : ControllerBase
    {
        private readonly ISaleOrderLineService _solService;

        public SaleOrderLineController(ISaleOrderLineService solService)
        {
            _solService = solService;
        }

        [HttpGet("GetAllBySaleOrder/{saleOrderId}")]
        public IActionResult GetAllBySaleOrder([FromRoute] int saleOrderId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
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

        [HttpGet("GetAllByProduct/{productId}")]
        public IActionResult GetAllByProduct([FromRoute] int productId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
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
