using Microsoft.AspNetCore.Mvc;

namespace Merchanmusic.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController (IUserService userService) { }
    }
}
