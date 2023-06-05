namespace Contacts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.ModelsValidationConstants.ValidationConstants.ContactValidations;

    public class Contact
    {
        public Contact()
        {
            this.ApplicationUsersContacts = new HashSet<ApplicationUserContact>();
        }

        [Key] public int Id { get; set; }

        [Required]
        [StringLength(ContactNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(ContactNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(ContactEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(ContactNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }

        [Required] public string Website { get; set; } = null!;


        public ICollection<ApplicationUserContact> ApplicationUsersContacts {get; set; }
    }
}