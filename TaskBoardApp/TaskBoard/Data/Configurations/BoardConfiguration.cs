using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Data.Models;

namespace TaskBoard.Data.Configurations
{
    public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasData(GenerateBoards());
        }

        private ICollection<Board> GenerateBoards()
        {
            var boards = new List<Board>();
            boards.Add(new Board()
                {
                    Id = 1,
                    Name = "Open"
                });
            boards.Add(new Board()
                {
                    Id = 2,
                    Name = "In Progress"
                }
            );

            boards.Add(new Board()
            {
                Id = 3,
                Name = "Done"
            });

            return boards;
        }
    }
}
