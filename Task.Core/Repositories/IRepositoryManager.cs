using TaskManage.Base.Repositories;
using TaskManage.ViewModels;

namespace TaskManage.Core.Repositories
{
    public interface IRepositoryManager
    {
        ITaskRepository TaskRepository { get; }
    }
}
