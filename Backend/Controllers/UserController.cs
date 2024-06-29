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
        public IActionResult EnsureUser([FromBody] UserPostDto userPostDto)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            bool isUserEnsured = _userService.EnsureUser(userPostDto, subClaim);
            if (isUserEnsured)
            {
                return Ok();
            } else
            {
                return BadRequest("Incorrect role or forbidden action");
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
            string loggedUserRole = _userService.GetUserRole(subClaim);
            User loggedUser = _userService.GetUserById(subClaim);

            if (loggedUserRole == "Admin" && loggedUser.State)
            {
                return Ok(_userService.GetUsersByRole(role));

            }
            return Forbid();
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] ClientUpdateDto clientUpdateDto)
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
