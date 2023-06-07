namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        [Key] public int Id { get; set; }

        [Required][StringLength(50)] public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; }
    }
}