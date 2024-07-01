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

        [HttpPost("ensure-user")]
        public IActionResult EnsureUser()
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string emailClaim = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            string roleClaim = this.User.Claims.FirstOrDefault(c => c.Type == "role").Value;
            Client client = new()
            {
                Id = subClaim,
                Email = emailClaim,
                Role = roleClaim
            };

            bool isUserEnsured = _userService.EnsureUser(client);
            if (isUserEnsured)
            {
                return Ok();
            } else
            {
                return BadRequest();
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
            string loggedUserRole = this.User.Claims.FirstOrDefault(c => c.Type == "role").Value;
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
            Client clientToUpdate = new Client()
            {
                Id = this.User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Address = clientUpdateDto.Address,
            };
            _userService.UpdateUser(clientToUpdate);
            return Ok();
        }

        [HttpPut("seller")]
        public IActionResult UpdateSeller([FromBody] ClientUpdateDto clientUpdateDto)
        {
            Client clientToUpdate = new Client()
            {
                Id = this.User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Address = clientUpdateDto.Address,
            };
            _userService.UpdateUser(clientToUpdate);
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
