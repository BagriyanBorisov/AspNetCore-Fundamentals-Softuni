namespace Contacts.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.ModelsValidationConstants.ValidationConstants.ContactValidations;
    public class ContactFormViewModel
    {
        [Required]
        [StringLength(ContactNameMaxLength,MinimumLength = ContactNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(ContactNameMaxLength, MinimumLength = ContactLastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [RegularExpression(ContactPhonePattern, ErrorMessage = ContactPhoneErrorMsg)]
        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }

        [Required]
        [RegularExpression(ContactWebsitePattern, ErrorMessage = ContactWebsiteErrorMsg)]
        public string Website { get; set; } = null!;
    }
}
