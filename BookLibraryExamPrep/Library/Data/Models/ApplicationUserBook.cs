using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class ApplicationUserBook
    {

        public string ApplicationUserId { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}
