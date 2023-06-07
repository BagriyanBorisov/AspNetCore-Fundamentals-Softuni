using Library.Models;

namespace Library.Contracts
{
    public interface IBooksService
    {
        Task<IEnumerable<BookViewModel>> GetBooks();
        Task<IEnumerable<CategoryViewModel>> GetCategories();
        Task AddBook(BookFormViewModel viewModel);
        Task AddToMyBooks(string userId, int bookId);
        Task RemoveFromMyBooks(string userId, int bookId);
        Task<IEnumerable<MyBookViewModel>> GetMyBooks(string userId);
    }
}
