using System.Security.Claims;

namespace FinanceTracker.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetId() => int.Parse(_httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);
    }
}
