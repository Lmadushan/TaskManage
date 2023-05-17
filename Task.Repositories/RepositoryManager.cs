using TaskManage.Core.Repositories;

namespace TaskManage.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        public ITaskRepository TaskRepository { get; set; }

        public RepositoryManager(ITaskRepository taskRepository)
        {
            TaskRepository = taskRepository;
        }
    }
}
