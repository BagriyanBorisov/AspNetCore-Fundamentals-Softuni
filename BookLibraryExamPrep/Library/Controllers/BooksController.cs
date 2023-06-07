using System.Security.Claims;

namespace Library.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Contracts;
    using Models;

    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService _booksService)
        {
            this.booksService = _booksService;
        }


        public async Task<IActionResult> All()
        {
            var models = await booksService.GetBooks();
            return View(models);
        }

        public async Task<IActionResult> Add()
        {
            var categories = await booksService.GetCategories();

            var book = new BookFormViewModel()
            {
                Categories = categories.ToList(),
            };
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await booksService.AddBook(model);
                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await booksService.AddToMyBooks(userId, bookId);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var models = await booksService.GetMyBooks(userId);

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await booksService.RemoveFromMyBooks(userId, bookId);
            return RedirectToAction(nameof(Mine));
        }
    }
}
