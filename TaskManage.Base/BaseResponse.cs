
using FluentValidation.Results;

namespace TaskManage.Base.DTOs
{
    public abstract class BaseResponse
    {
        public string? Message { get; set; }

        public string? MessageDetails { get; set; }

        // public ResponseStatus Status { get; set; }

        public IList<ValidationFailure>? ValidationErrors { get; set; }

        public DateTime LastAccessedDateTime { get; set; }

        public bool IsSuccess { get; set; }
    }
}
