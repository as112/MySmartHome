namespace Client.Blazor.Data
{
    public class Token
    {
        public string? access_token { get; set; }
        public string? username { get; set; }

        public static Dictionary<string, string> tokens = new();
    }
}
