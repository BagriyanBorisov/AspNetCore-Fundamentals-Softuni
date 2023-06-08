using System.Security.Claims;

namespace TaskBoard.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Contracts;
    using ViewModels.TaskVMs;

    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService _taskService)
        {
            this.taskService = _taskService;
        }

        public async Task<IActionResult> Create()
        {
            var model = await taskService.GetFormTaskAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FormTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await taskService.AddTaskAsync(model, currentUserId);


            return RedirectToAction("All","Board");
        }
    }
}
