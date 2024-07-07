using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Models;
using Merchanmusic.Enums;
using Merchanmusic.Services.Implementations;
using Merchanmusic.Services.Interfaces;
using AutoMapper;


namespace Merchanmusic.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        

        [HttpGet]
        public IActionResult GetAllUsers() 
        {
            var users = _userService.GetAllUsers();
            try
            {
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpGet("role")]
        public IActionResult GetRoleById()
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(_userService.GetRoleById(subClaim));
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

        [HttpDelete]
        public IActionResult DeleteSelfUser()
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _userService.DeleteUser(subClaim);
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateClient([FromBody] ClientPostDto clientPostDto)
        {
            bool userExists = _userService.CheckIfUserExists(clientPostDto.Id);
            if (!userExists)
            {
                Client newClient = new()
                {
                    Id = clientPostDto.Id,
                    Email = clientPostDto.Email,
                };
                _userService.CreateUser(newClient);
            }
            return Ok();
        }

        [HttpPut("waiting-validation/{waitingValidation}")]
        public IActionResult UpdateWaitingValidation([FromRoute] bool waitingValidation)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _userService.UpdateValidationStatus(subClaim, waitingValidation);
            return Ok();
        }

        [HttpPut("client")]
        public IActionResult UpdateClient([FromBody] ClientUpdateDto clientUpdateDto)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var existingClient = _userService.GetUserById(subClaim);

            if (existingClient is Client && existingClient != null)
            {
                _mapper.Map(clientUpdateDto, existingClient);
                _userService.UpdateUser(existingClient);
                return Ok();
            } else
            {
                return BadRequest($"User with id {subClaim} is not a Client or doesn't exist");
            }
        }

        //[HttpPut("upgrade-client")] PARA QUE ADMIN CONVIERTA A CLIENT EN SELLER

        [HttpPut("seller")]
        public IActionResult UpdateSeller([FromBody] SellerUpdateDto sellerUpdateDto)
        {
            string subClaim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var existingSeller = _userService.GetUserById(subClaim);

            _mapper.Map(sellerUpdateDto, existingSeller);

            _userService.UpdateUser(existingSeller);
            return Ok();
        }

        
    }

}
