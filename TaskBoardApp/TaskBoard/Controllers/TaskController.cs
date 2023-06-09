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

            string? currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await taskService.AddTaskAsync(model, currentUserId);


            return RedirectToAction("All","Board");
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await taskService.GetDetailsAsync(id);
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await taskService.GetFormTaskForEditAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FormTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await taskService.EditTaskAsync(id, model);
            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await taskService.GetDeleteAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel model)
        {
            await taskService.DeleteTaskAsync(model);
            return RedirectToAction("All", "Board");
        }

    }
}
