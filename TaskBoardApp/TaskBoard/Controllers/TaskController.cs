using Microsoft.AspNetCore.Mvc;
using TaskBoard.Contracts;

namespace TaskBoard.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService _taskService)
        {
            this.taskService = _taskService;
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
