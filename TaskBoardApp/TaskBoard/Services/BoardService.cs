using Microsoft.EntityFrameworkCore;
using TaskBoard.Contracts;
using TaskBoard.Data;
using TaskBoard.ViewModels.BoardVMs;
using TaskBoard.ViewModels.TaskVMs;

namespace TaskBoard.Services
{
    public class BoardService : IBoardService
    {
        private readonly ApplicationDbContext dbContext;

        public BoardService(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<IEnumerable<BoardViewModel>> GetAllAsync()
        {
            return await dbContext.Boards.Select(b => new BoardViewModel()
            {
                Id = b.Id,
                Name = b.Name,
                Tasks = b.Tasks
                    .Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.User.UserName
                    })
            }).ToListAsync();
        }
    }
}
