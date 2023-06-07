using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BooksService : IBooksService
    {
        private readonly LibraryDbContext context;

        public BooksService(LibraryDbContext _context)
        {
            this.context = _context;
        }

        public async Task AddBook(BookFormViewModel viewModel)
        {
            var book = new Book()
            {
                Title = viewModel.Title,
                Author = viewModel.Author,
                CategoryId = viewModel.CategoryId,
                Description = viewModel.Description,
                ImageUrl = viewModel.ImageUrl,
                Rating = viewModel.Rating
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MyBookViewModel>> GetMyBooks(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u=>u.ApplicationUsersBooks)
                .ThenInclude(ap => ap.Book)
                .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync();

            if (user == null) throw new ArgumentException("User Invalid ID");

            return user.ApplicationUsersBooks.Select(ab => new MyBookViewModel()
            {
                Title = ab.Book.Title,
                Author = ab.Book.Author,
                Category = ab.Book.Category.Name,
                ImageUrl = ab.Book.ImageUrl,
                Id = ab.Book.Id,
                Description = ab.Book.Description
            });
        }

        public async Task<IEnumerable<BookViewModel>> GetBooks()
        {
            return await context.Books.Include(b => b.Category)
                .Select(book => new BookViewModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    ImageUrl = book.ImageUrl,
                    Category = book.Category.Name,
                    Rating = book.Rating
                }).ToListAsync();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return await context.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();
        }

        public async Task AddToMyBooks(string userId, int bookId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks).FirstOrDefaultAsync();

            var book = await context.Books.Where(b => b.Id == bookId).FirstOrDefaultAsync();

            if (book == null) throw new ArgumentException("Invalid Book ID");

            if (user == null || user.ApplicationUsersBooks.Any(ap => ap.BookId == book.Id))
            {
                return;
            }

            var userBook = new ApplicationUserBook()
            {
                ApplicationUserId = userId,
                ApplicationUser = user,
                BookId = bookId,
                Book = book
            };
            user.ApplicationUsersBooks.Add(userBook);
            await context.SaveChangesAsync();

        }

        public async Task RemoveFromMyBooks(string userId, int bookId)
        {
            var user = await context.Users.Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .ThenInclude(ap => ap.Book).FirstOrDefaultAsync();

            if (user == null) throw new ArgumentException("User Invalid ID");

            var contact = user.ApplicationUsersBooks.FirstOrDefault(c => c.BookId == bookId);

            if (contact != null)
            {
                user.ApplicationUsersBooks.Remove(contact);
                await context.SaveChangesAsync();
            }
        }
    }
}
