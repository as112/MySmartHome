using MySmartHome.DAL.Models;

namespace MySmartHome.DAL.Data
{
    public interface ITokenStorage
    {
        string? GetToken(string username);
        void SetToken(Token token);
    }
}
