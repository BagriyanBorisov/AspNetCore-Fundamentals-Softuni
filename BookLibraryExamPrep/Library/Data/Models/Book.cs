namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public Book()
        {
            ApplicationUsersBooks = new HashSet<ApplicationUserBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(5000)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public ICollection<ApplicationUserBook> ApplicationUsersBooks { get; set; }
    }
}