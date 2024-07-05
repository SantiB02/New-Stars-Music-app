using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Models;
using Merchanmusic.Enums;
using Merchanmusic.Services.Implementations;


namespace Merchanmusic.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("role")]
        public IActionResult GetRoleById()
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(_userService.GetRoleById(subClaim));
        }

        [HttpPost("ensure-user/{email}")]
        public IActionResult EnsureUser([FromRoute] string email)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Client client = new()
            {
                Id = subClaim,
                Email = email,
            };

            _userService.EnsureUser(client);
            return Ok();
        }

        [HttpGet("is-deleted/{id}")]
        public IActionResult IsUserDeleted([FromRoute] string id)
        {
            bool userExists = _userService.CheckIfUserExists(id);
            if (userExists)
            {
                bool isUserDeleted = _userService.IsUserDeleted(id);
                if (isUserDeleted)
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            } else
            {
                return NotFound($"User with id {id} doesn't exist");
            }
            
        }

        [HttpGet("user-info")]
        public IActionResult GetUserInfo()
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            User? user = _userService.GetUserById(subClaim);

            if (user != null && user.State)
            {
                UserInfoDto userInfoDto = new UserInfoDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Address = user.Address,

                };
                return Ok(userInfoDto);
            }
            return BadRequest();
        }

        [HttpGet("by-role/{role}")]
        public IActionResult GetClients([FromRoute] string role)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string loggedUserRole = _userService.GetRoleById(subClaim);
            User loggedUser = _userService.GetUserById(subClaim);
            if (loggedUserRole == "Admin" && loggedUser.State)
            {
                return Ok(_userService.GetUsersByRole(role));

            }
            return Forbid();
        }

        [HttpPut("client")]
        public IActionResult UpdateClient([FromBody] ClientUpdateDto clientUpdateDto)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            User existingClient = _userService.GetUserById(subClaim);

            existingClient.Address = clientUpdateDto.Address;
            existingClient.Apartment = clientUpdateDto.Apartment;
            existingClient.Country = clientUpdateDto.Country;
            existingClient.City = clientUpdateDto.City;
            existingClient.PostalCode = clientUpdateDto.PostalCode;
            existingClient.Phone = clientUpdateDto.Phone;
            existingClient.WaitingValidation = clientUpdateDto.WaitingValidation; //ESTE VALOR NO SE ASIGNA NUNCA!!! NO SÉ POR QUÉ

            _userService.UpdateUser(existingClient);
            return Ok();
        }

        //[HttpPut("upgrade-client")] PARA QUE ADMIN CONVIERTA A CLIENT EN SELLER

        [HttpPut("seller")]
        public IActionResult UpdateSeller([FromBody] SellerUpdateDto sellerUpdateDto)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var existingSeller = _userService.GetUserById(subClaim);

            existingSeller.Address = sellerUpdateDto.Address;
            existingSeller.Apartment = sellerUpdateDto.Apartment;
            existingSeller.Country = sellerUpdateDto.Country;
            existingSeller.City = sellerUpdateDto.City;
            existingSeller.PostalCode = sellerUpdateDto.PostalCode;
            existingSeller.Phone = sellerUpdateDto.Phone;

            _userService.UpdateUser(existingSeller);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteSelfUser()
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _userService.DeleteUser(subClaim);
            return Ok();
        }
    }

}
