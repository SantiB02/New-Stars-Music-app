using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Models;
using Merchanmusic.Services.Implementations;
using Merchanmusic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Merchanmusic.Controllers
{
    [Route("api/messages")]
    [ApiController]
    [Authorize]
    public class MessageBoardController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IMessageBoardService _messageBoardService;

        public MessageBoardController(IUserService userService, ITokenService tokenService, IMessageBoardService messageBoardService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _messageBoardService = messageBoardService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMessageBoards()
        {
            try
            {
                List<Message> messages = _messageBoardService.GetAllMessages();
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateNewMessage([FromBody] MessageDto messageDto)
        {
            string subClaim = _tokenService.GetUserId();
            string role = _userService.GetRoleById(subClaim);

            if (role == "Admin")
            {
                if (string.IsNullOrEmpty(messageDto.MessageBody))
                {
                    return BadRequest("Message body can't be empty");
                }
                try
                {
                    Message message = new Message
                    {
                        MessageBody = messageDto.MessageBody,
                        // Asigna otros campos necesarios aquí
                    };

                    _messageBoardService.CreateMessage(message);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }

        [HttpPut("edit/{id}")]
        public IActionResult EditMessage(int id, [FromBody] string newMessage)
        {
            string subClaim = _tokenService.GetUserId();
            string role = _userService.GetRoleById(subClaim);

            if (role == "Admin")
            {
                try
                {
                    var message = _messageBoardService.UpdateMessage(newMessage, id);
                    if (message == null)
                    {
                        return NotFound($"No message found with ID: {id}");
                    }

                    return Ok($"Message with ID: {id} was successfully updated");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            string subClaim = _tokenService.GetUserId();
            string role = _userService.GetRoleById(subClaim);

            if (role == "Admin")
            {
                try
                {
                    _messageBoardService.DeleteMessage(id);
                    return Ok($"Message with ID: {id} was successfully deleted");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }
    }
}
