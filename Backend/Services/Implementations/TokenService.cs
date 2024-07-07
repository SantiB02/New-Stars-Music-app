using Merchanmusic.Services.Interfaces;
using System.Security.Claims;

namespace Merchanmusic.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId()
        {
            var httpContext = _contextAccessor.HttpContext;
            return httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
