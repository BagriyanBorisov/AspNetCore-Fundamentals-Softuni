using TaskBoard.ViewModels.TaskVMs;

namespace TaskBoard.Contracts
{
    public interface ITaskService
    {
        Task<FormTaskViewModel> GetFormTaskAsync();
        Task AddTaskAsync(FormTaskViewModel model, string userId);
    }
}
