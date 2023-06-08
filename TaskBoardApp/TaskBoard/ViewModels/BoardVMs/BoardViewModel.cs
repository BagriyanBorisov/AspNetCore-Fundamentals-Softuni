using TaskBoard.ViewModels.TaskVMs;

namespace TaskBoard.ViewModels.BoardVMs
{
    public class BoardViewModel
    {
        public BoardViewModel()
        {
            this.Tasks = new List<TaskViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
}
