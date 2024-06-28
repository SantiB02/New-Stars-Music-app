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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("user-info")]
        public IActionResult GetUserInfo()
        {
            string loggedUserEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            User? user = _userService.GetUserByEmail(loggedUserEmail);

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

        [HttpGet]
        public IActionResult GetClients()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            string loggedUserEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            User userLogged = _userService.GetUserByEmail(loggedUserEmail);

            if (role == "Admin" && userLogged.State)
            {
                return Ok(_userService.GetUsersByRole((int)UserRoleEnum.Client));

            }
            return Forbid();
        }

        [HttpPut]
        public IActionResult UpdateClient([FromBody] ClientUpdateDto clientToUpdateDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Client")
            {
                Client clientToUpdate = new Client()
                {
                    Id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                    Address = clientToUpdateDto.Address,
                };
                _userService.UpdateUser(clientToUpdate);
                return Ok();

            }
            return Forbid();
        }
        [HttpDelete]
        public IActionResult DeleteSelfUser()
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            _userService.DeleteUser(id);
            return Ok();
        }
    }

}
