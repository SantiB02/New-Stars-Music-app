using AutoMapper;
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
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public SaleOrderController(ISaleOrderService saleOrderService, IUserService userService, ITokenService tokenService, IMapper mapper)
        {
            _saleOrderService = saleOrderService;
            _userService = userService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpGet("by-client/{clientId}")]
        public IActionResult GetAllByClient([FromRoute] string clientId)
        {
            string subClaim = _tokenService.GetUserId();
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
            string subClaim = _tokenService.GetUserId();
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
            string subClaim = _tokenService.GetUserId();
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
            string subClaim = _tokenService.GetUserId();
     
            if (dto == null)
            {
                return BadRequest("Sale Order can't be empty");
            }
            try
            {
                SaleOrder newSaleOrder = new()
                {
                    OrderCode = Guid.NewGuid().ToString(),
                    Date = DateTime.Now,
                    Total = dto.Total,
                    ClientId = subClaim
                };
                _mapper.Map(dto.LinesDto, newSaleOrder.SaleOrderLines);
              
                newSaleOrder = _saleOrderService.CreateSaleOrder(newSaleOrder);
                return Ok($"Sale Order successfully created with ID: {newSaleOrder.Id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSaleOrder([FromRoute] int id)
        {
            string subClaim = _tokenService.GetUserId();
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
        public IActionResult CompleteSaleOrder([FromRoute] int id)
        {
            string subClaim = _tokenService.GetUserId();
            string loggedUserRole = _userService.GetRoleById(subClaim);
            if (loggedUserRole == "Admin")
            {
                var soToUpdate = _saleOrderService.GetOne(id);
                if (soToUpdate == null)
                {
                    return NotFound($"Sale Order with ID {id} not found");
                }

                try
                {
                    soToUpdate.Completed = true;

                    soToUpdate = _saleOrderService.UpdateSaleOrder(soToUpdate);
                    return Ok($"Sale Order completed successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error updating Sale Order: {ex.Message}");
                }
            }
            return Forbid();
        }
    }
}
