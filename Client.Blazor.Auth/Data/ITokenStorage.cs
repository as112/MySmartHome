namespace Client.Blazor.Auth.Data
{
    public interface ITokenStorage
    {
        string? GetToken(string username);
        void SetToken(Token token);
    }
}
