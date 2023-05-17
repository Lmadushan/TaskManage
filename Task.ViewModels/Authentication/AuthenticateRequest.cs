namespace TaskManage.ViewModels
{
    public class AuthenticateRequest
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string? AdToken { get; set; }
        public string? AuthMode { get; set; }
    }
}
