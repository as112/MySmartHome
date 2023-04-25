using Microsoft.AspNetCore.Components.Authorization;

namespace MySmartHome.DAL.Models
{
    public class Token
    {
        public string? access_token { get; set; }
        public string? username { get; set; }

    }
}
