namespace TaskManage.Base.DTOs
{
    public class BaseException : Exception
    {
        public BaseResponse Response { get; set; }

        public BaseException(Exception innerException, BaseResponse response)
            : base("", innerException)
        {
            Response = response;
        }
    }
}
