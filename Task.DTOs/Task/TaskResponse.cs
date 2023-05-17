using TaskManage.Base.DTOs;
using TaskManage.ViewModels;

namespace TaskManage.DTOs
{
    public class TaskResponse : BaseResponse
    {
        public TaskVM Task { get; set; }
    }
}
