namespace TaskBoard.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Contracts;

    [Authorize]
    public class BoardController : Controller
    {
        private readonly IBoardService boardService;

        public BoardController(IBoardService _boardService)
        {
            this.boardService = _boardService;
        }

        public async Task<IActionResult> All()
        {
           var models = await boardService.GetAllAsync();
            return View(models);
        }
    }
}
