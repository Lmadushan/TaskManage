using TaskManage.ViewModels;

namespace TaskManage.Core.Services
{
    public interface ITaskService
    {
        Task<TaskVM> Get(string id);
        Task<List<TaskVM>> GetAll();
        Task<TaskVM> Create(TaskVM task);
        Task Update(TaskVM task);
        Task Delete(string Id);
    }
}
