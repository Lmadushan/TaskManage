using TaskManage.Base.DTOs;
using TaskManage.ViewModels;

namespace TaskManage.DTOs
{
    public class TaskListResponse : BaseResponse
    {
        public IEnumerable<TaskVM> Tasks { get; set; } = new List<TaskVM>();
    }
}
