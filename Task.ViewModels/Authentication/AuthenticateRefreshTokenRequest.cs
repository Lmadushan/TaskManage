namespace TaskManage.ViewModels
{
    public class AuthenticateRefreshTokenRequest
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? UserName { get; set; }
    }
}
