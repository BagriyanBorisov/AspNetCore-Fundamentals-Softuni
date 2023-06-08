namespace TaskBoard.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.Validations.EntityValidations.BoardValidations;

    public class Board
    {

        public Board()
        {
            this.Tasks = new HashSet<Task>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = null!;

        public ICollection<Task> Tasks { get; set; }
    }
}
