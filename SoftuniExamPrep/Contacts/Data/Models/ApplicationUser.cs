namespace Contacts.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.ApplicationUsersContacts = new HashSet<ApplicationUserContact>();
        }

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }
    }
}
