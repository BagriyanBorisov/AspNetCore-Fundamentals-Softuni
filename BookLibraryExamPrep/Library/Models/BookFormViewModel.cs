namespace Library.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.ValidationConstants.Validations.BookValidations;

    public class BookFormViewModel
    {
        public BookFormViewModel()
        {
            this.Categories = new List<CategoryViewModel>();
        }

        [Required]
        [StringLength(BookTitleMaxLength,MinimumLength = BookTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(BookAuthorMaxLength, MinimumLength = BookAuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(BookDescriptionMaxLength, MinimumLength = BookDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.0", "10.0")]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
