using TaskManage.Base.DTOs;

namespace TaskManage.DTOs
{
    public class TaskRequest : BaseRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AttachmentId { get; set; }
    }
}
