using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Data.Models
{
    public class ApplicationUserContact
    {

        [Required]
        public string ApplicationUserId { get; set; } = null!;

        [Required] 
        public int ContactId { get; set; } 

        [ForeignKey(nameof(ContactId))]
        public Contact Contact { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;


    }
}
