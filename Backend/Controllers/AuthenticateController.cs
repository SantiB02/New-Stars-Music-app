//using Merchanmusic.Data.Entities;
//using Merchanmusic.Data.Models;
//using Merchanmusic.Services.Interfaces;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace Merchanmusic.Controllers

//{
//	[Route]
//	public AuthenticateController: Controller
//	{
//	[Route("api/[controller]")]
//	[ApiController]
//	public class AuthenticateController : ControllerBase
//    {
//		public IUserService _userService;
//		public IConfiguration _config;

//		public AuthenticateController(IUserService userService, IConfiguration config)
//		{
//			_userService = userService;
//			_config = config;
//		}

//		[HttpPost]
//		public IActionResult Authenticate([FromBody] CredentialsDto credentialsDto)
//		{
//			BaseResponse validateUserResult = _userService.ValidateUser(credentialsDto.Email,credentialsDto.Password);
//			if (validateUserResult.Message =="wrong email")
//			{
//				return BadRequest(validateUserResult.Message);
//			}else if (validateUserResult.Message =="wrong password")
//            {
//				return Unauthorized();

//            }
			
			
			
//			if (validateUserResult.Result)
//            {
//				validateUserResult user = _userService.GetUserByEmail(credentialsDto.Email);

//				var securityPassword = new SymmetricSecurityKet(Encoding.ASCII.GetBytes(_config["Authentication:SecretForkey"]));

//				var signature = new SigningCredentials( securityPassword, SecurityAlgorithms.HmacSha256 );

//				var claimsForToken = new List<Claim>();
//				claimsForToken.Add(new Claim("sub", user.Id.ToString()));
//				claimsForToken.Add(new Claim("email", user.Email));
//				claimsForToken.Add(new Claim("role", user.UserType));

//				var jwtSecurityToken = new JwtSecurityToken(new()
//				{
//					_config["Authentication:Issuer"],
//					_config["Authentication:Audience"],
//					claimsForToken,
//					DateTime.UtcNow,
//					DateTime.UtcNow.AddHours(1),
//					signature);

//				string tokenReturn = new JwtSecurityTokenHandler().writeToken(jwtSecurityToken);
//				return ok(tokenReturn);
//				}
//				return BadRequest();

//            }
//        }
//}
