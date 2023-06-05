using Contacts.Data.Models;
using System.ComponentModel.DataAnnotations;
using static Contacts.Common.ModelsValidationConstants.ValidationConstants.ContactValidations;

namespace Contacts.Models
{
    public class ContactViewModel
    {
        
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }

        [Required]
        public string Website { get; set; } = null!;

    }
}
