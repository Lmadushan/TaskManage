namespace TaskManage.DTOs
{
    public class ErrorResponse
    {
        public List<string>? ValidationErrors { get; set; }
        public bool Success { get; private set; } = false;
        public string? Message { get; set; }
    }
}
