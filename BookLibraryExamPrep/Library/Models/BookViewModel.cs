using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal), "0.0", "10.0")]
        public decimal Rating { get; set; }

        public string Category { get; set; } = null!;

    }
}
