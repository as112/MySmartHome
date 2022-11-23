using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Blazor.Auth.Data
{
    public class Token
    {
        public string? access_token { get; set; }
        public string? username { get; set; }

        //public Dictionary<string, string> tokens = new();
        //private readonly AuthenticationStateProvider _provider;

        //public Token(AuthenticationStateProvider provider)
        //{
        //    _provider = provider;
        //}

        //public async Task<string> GetTokenAsync()
        //{
        //    var authState = await _provider.GetAuthenticationStateAsync();
        //    var user = authState.User;
        //    return tokens[user.FindFirst(c => c.Type == ClaimTypes.Email)?.Value!];
        //}
    }
}
