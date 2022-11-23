using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Client.Blazor.Auth.Data
{
    public class TokenStorage
    {
        public List<Token> tokens { get; set; } = new List<Token>();

        public string GetTokenByEmail(string email) => tokens.FirstOrDefault(s => s.username == email)?.access_token ?? "";
    }
}
