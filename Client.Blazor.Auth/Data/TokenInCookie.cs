using MySmartHome.DAL.Data;
using MySmartHome.DAL.Models;

namespace Client.Blazor.Auth.Data
{
    public class TokenInCookie : ITokenStorage
    {
        
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenInCookie(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string? GetToken(string username)
        {
            if (string.IsNullOrEmpty(username)) return null;
            var tokenName = username.Replace('@', '-');
            return _httpContextAccessor?.HttpContext?.Request?.Cookies?[tokenName];
        }

        public void SetToken(Token token)
        {
            var tokenName = token.username.Replace('@','-');
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };
            _httpContextAccessor?.HttpContext?.Response.Cookies.Append(tokenName, token.access_token, cookieOptions);

        }
    }
}
