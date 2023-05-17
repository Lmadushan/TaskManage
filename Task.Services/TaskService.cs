
using TaskManage.Core.Repositories;
using TaskManage.Core.Services;
using TaskManage.ViewModels;

namespace TaskManage.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepositoryManager _repositoryManager;
        public TaskService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<TaskVM> Get(string id)
            => await _repositoryManager.TaskRepository.GetByIdAsync(id);

        public async Task<List<TaskVM>> GetAll()
            => await _repositoryManager.TaskRepository.ListAllAsync(true);

        public async Task<TaskVM> Create(TaskVM task)
            => await _repositoryManager.TaskRepository.AddAsync(task);

        public async Task Update(TaskVM task)
            => await _repositoryManager.TaskRepository.UpdateAsync(task);

        public async Task Delete(string Id)
        {
            TaskVM task = await _repositoryManager.TaskRepository.GetByIdAsync(Id);
            await _repositoryManager.TaskRepository.DeleteAsync(task);
        }
    }
}
