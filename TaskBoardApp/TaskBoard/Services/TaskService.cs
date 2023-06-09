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

        public async System.Threading.Tasks.Task DeleteTaskAsync(TaskViewModel model)
        {
            var task = await dbContext.Tasks.FindAsync(model.Id);

            if (task != null)
            {
                dbContext.Tasks.Remove(task);
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<TaskDetailsViewModel> GetDetailsAsync(int taskId)
        {
            var task = await dbContext.Tasks
                .Include(t => t.Board)
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == taskId);

            TaskDetailsViewModel detailsTask = new TaskDetailsViewModel();
            if (task != null)
            {
                detailsTask.Board = task.Board?.Name ?? "Error";
                detailsTask.Title = task.Title;
                detailsTask.Description = task.Description;
                detailsTask.CreatedOn = task.CreatedOn.ToShortDateString();
                detailsTask.Id = task.Id;
                detailsTask.Owner = task.User.UserName;
            }
            return detailsTask;
        }

        public async Task<FormTaskViewModel> GetFormTaskForEditAsync(int taskId)
        {
            var task = await dbContext.Tasks.FindAsync(taskId); 
            var boards = await dbContext.Boards.Select(board => new FormBoardViewModel()
            {
                Id = board.Id,
                Name = board.Name,
            }).ToListAsync();

            FormTaskViewModel editTask = new FormTaskViewModel();
            if (task != null)
            {
                editTask.BoardId = task.BoardId;
                editTask.Title = task.Title;
                editTask.Description = task.Description;
                editTask.Boards = boards;
            }

            return editTask;
        }

        public async System.Threading.Tasks.Task EditTaskAsync(int taskId, FormTaskViewModel model)
        {
            var task = await dbContext.Tasks
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == taskId);

            if (task != null)
            {
                task.Title = model.Title;
                task.Description = model.Description;
                task.BoardId = model.BoardId;
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<TaskViewModel> GetDeleteAsync(int taskId)
        {
            var task = await dbContext.Tasks.FindAsync(taskId);

            TaskViewModel deleteTask = new TaskViewModel();

            if (task != null)
            {
                deleteTask.Description = task.Description;
                deleteTask.Title = task.Title;
            }

            return deleteTask;
            
        }
    }
}
