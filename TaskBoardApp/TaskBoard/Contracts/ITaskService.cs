using TaskBoard.ViewModels.TaskVMs;

namespace TaskBoard.Contracts
{
    public interface ITaskService
    {
        Task<FormTaskViewModel> GetFormTaskAsync();
        Task<FormTaskViewModel> GetFormTaskForEditAsync(int taskId);
        Task AddTaskAsync(FormTaskViewModel model, string userId);
        Task EditTaskAsync(int taskId,FormTaskViewModel model);
        Task DeleteTaskAsync(TaskViewModel model);
        Task<TaskDetailsViewModel> GetDetailsAsync(int taskId);
        Task<TaskViewModel> GetDeleteAsync(int taskId);

    }
}
