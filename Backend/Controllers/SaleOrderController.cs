using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Models;
using Merchanmusic.Services.Implementations;
using Merchanmusic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Merchanmusic.Controllers
{
    [Route("api/sale-orders")]
    [ApiController]
    [Authorize]
    public class SaleOrderController : ControllerBase
    {
        private readonly ISaleOrderService _saleOrderService;
        private readonly IUserService _userService;

        public SaleOrderController(ISaleOrderService saleOrderService, IUserService userService)
        {
            _saleOrderService = saleOrderService;
            _userService = userService;
        }

        [HttpGet("by-client/{clientId}")]
        public IActionResult GetAllByClient([FromRoute] string clientId)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string loggedUserRole = _userService.GetRoleById(subClaim);
            if (loggedUserRole == "Admin" || loggedUserRole == "Client")
            {
                try
                {
                    var saleOrders = _saleOrderService.GetAllByClient(clientId);
                    if (saleOrders.Count == 0)
                    {
                        return NotFound("Órdenes de venta no encontradas");
                    }
                    return Ok(saleOrders);

                }
                catch (Exception ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            }
            return Forbid();
        }

        [HttpGet("by-date/{date}")]
        public IActionResult GetAllByDate([FromRoute] DateTime date)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string loggedUserRole = _userService.GetRoleById(subClaim);
            if (loggedUserRole == "Admin")
            {
                try
                {
                    var saleOrders = _saleOrderService.GetAllByDate(date);
                    if (saleOrders.Count == 0)
                    {
                        return NotFound($"No hay Órdenes de venta para la fecha seleccionada");
                    }
                    return Ok(saleOrders);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            }
            return Forbid();
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOne([FromRoute] int orderId)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string loggedUserRole = _userService.GetRoleById(subClaim);
            if (loggedUserRole == "Admin")
            {
                try
                {
                    var saleOrder = _saleOrderService.GetOne(orderId);

                    if (saleOrder == null)
                    {
                        return NotFound($"Orden de venta con id {orderId} no encontrada");
                    }

                    return Ok(saleOrder);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            }
            return Forbid();
        }

        [HttpPost]
        public IActionResult CreateSaleOrder([FromBody] SaleOrderDto dto)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string loggedUserRole = _userService.GetRoleById(subClaim);
            if (loggedUserRole == "Admin" || loggedUserRole == "Client")
            {
                if (dto == null)
                {
                    return BadRequest("Por favor complete los campos");
                }
                try
                {
                    var newSaleOrder = new SaleOrder()
                    {
                        ClientId = dto.ClientId,
                        Date = DateTime.Now
                    };
                    newSaleOrder = _saleOrderService.CreateSaleOrder(newSaleOrder);
                    return Ok($"Orden de venta creada exitosamente con ID: {newSaleOrder.Id}");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSaleOrder([FromRoute] int id)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string loggedUserRole = _userService.GetRoleById(subClaim);
            if (loggedUserRole == "Admin" || loggedUserRole == "Client")
            {
                try
                {
                    var existingSO = _saleOrderService.GetOne(id);

                    if (existingSO == null)
                    {
                        return NotFound($"No se encontró orden de venta con el ID: {id}");
                    }

                    _saleOrderService.DeleteSaleOrder(id);
                    return Ok($"Orden de venta con ID: {id} eliminada");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateSaleOrder([FromRoute] int id, [FromBody] SaleOrderDto dto)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string loggedUserRole = _userService.GetRoleById(subClaim);
            if (loggedUserRole == "Admin")
            {
                var soToUpdate = _saleOrderService.GetOne(id);
                if (soToUpdate == null)
                {
                    return NotFound($"Orden de venta con ID {id} no encontrada");
                }

                try
                {
                    soToUpdate.ClientId = dto.ClientId;

                    soToUpdate = _saleOrderService.UpdateSaleOrder(soToUpdate);
                    return Ok($"Orden de venta actualizada exitosamente");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error al actualizar Orden de venta: {ex.Message}");
                }
            }
            return Forbid();
        }
    }
}
