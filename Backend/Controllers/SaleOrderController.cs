using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Models;
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

        public SaleOrderController(ISaleOrderService saleOrderService)
        {
            _saleOrderService = saleOrderService;
        }

        [HttpGet("by-client/{clientId}")]
        public IActionResult GetAllByClient([FromRoute] int clientId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin" || role == "Client")
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
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
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
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
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
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin" || role == "Client")
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
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin" || role == "Client")
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
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                var soToUpdate = _saleOrderService.GetOne(id);
                if (soToUpdate == null)
                {
                    return NotFound($"Orden de venta con ID {id} no encontrada");
                }
                if (dto.ClientId == 0)
                {
                    return BadRequest("Orden de venta no actualizado, por favor completar los campos");
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
