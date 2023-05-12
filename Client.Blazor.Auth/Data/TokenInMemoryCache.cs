using Microsoft.Extensions.Caching.Memory;
using MySmartHome.DAL.Data;
using MySmartHome.DAL.Models;

namespace Client.Blazor.Auth.Data
{
    public class TokenInMemoryCache : ITokenStorage
    {
        private readonly IMemoryCache _memoryCache;

        public TokenInMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public string? GetToken(string username)
        {
            return _memoryCache.Get<string>(username);
        }

        public void SetToken(Token token)
        {
            _memoryCache.Set(token.username!, token.access_token);
        }
    }
}
