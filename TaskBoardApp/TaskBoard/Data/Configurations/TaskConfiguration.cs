using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using Task = TaskBoard.Data.Models.Task;

namespace TaskBoard.Data.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GenerateTasks());
        }

        private ICollection<Task> GenerateTasks()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(new Task()
            {
                Id = 1,
                Title = "Improve CSS styles",
                Description = "Implement better styling for all public pages",
                CreatedOn = DateTime.Now.AddDays(-200),
                OwnerId = "2916587f-6c8e-4494-949c-c2e79b95beb7",
                BoardId = 1
            });
            tasks.Add(new Task()
            {
                Id = 2,
                Title = "Android Client app",
                Description = "Create Android client app for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddMonths(-5),
                OwnerId = "502a30c1-3b34-487c-b18a-f0154358a22d",
                BoardId = 1
            });
            tasks.Add(new Task()
            {
                Id = 3,
                Title = "Desktop Client App",
                Description = "Create Windows Forms desktop app client for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddDays(-1),
                OwnerId = "502a30c1-3b34-487c-b18a-f0154358a22d",
                BoardId = 2
            });
            tasks.Add(new Task()
            {
                Id = 4,
                Title = "Create Tasks",
                Description = "Implement [Create Task] page for adding new tasks",
                CreatedOn = DateTime.Now.AddYears(-1),
                OwnerId = "2916587f-6c8e-4494-949c-c2e79b95beb7",
                BoardId = 3
            });

            return tasks;
        }
    }
}
