using Microsoft.EntityFrameworkCore;
using TaskBoard.Contracts;
using TaskBoard.Data;
using TaskBoard.ViewModels.BoardVMs;
using TaskBoard.ViewModels.TaskVMs;
using Task = TaskBoard.Data.Models.Task;

namespace TaskBoard.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext dbContext;

        public TaskService(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<FormTaskViewModel> GetFormTaskAsync()
        {
            var boards = await dbContext.Boards.Select(board => new FormBoardViewModel()
            {
                Id = board.Id,
                Name = board.Name,
            }).ToListAsync();

            var task = new FormTaskViewModel { Boards = boards };


            return task;
        }


        public async System.Threading.Tasks.Task AddTaskAsync(FormTaskViewModel model,string userId)
        {
            var task = new Task()
            {
                Title = model.Title,
                Description = model.Description,
                BoardId = model.BoardId,
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId,
            };

            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();
        }
    }
}
