using TaskBoard.Contracts;
using TaskBoard.Data;

namespace TaskBoard.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext dbContext;

        public TaskService(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
    }
}
