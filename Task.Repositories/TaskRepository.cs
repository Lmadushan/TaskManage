using TaskManage.Base.Repositories;
using TaskManage.Core.Repositories;
using TaskManage.Data;
using TaskManage.ViewModels;

namespace TaskManage.Repositories
{
    public class TaskRepository : BaseRepository<TaskVM>, ITaskRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TaskRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
