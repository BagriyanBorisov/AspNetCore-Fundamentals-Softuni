using TaskBoard.ViewModels.BoardVMs;

namespace TaskBoard.Contracts
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardViewModel>> GetAllAsync();
    }
}
