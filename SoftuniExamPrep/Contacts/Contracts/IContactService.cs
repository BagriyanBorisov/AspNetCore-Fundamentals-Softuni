using Contacts.Models;

namespace Contacts.Contracts
{
    public interface IContactService
    {
        Task<IEnumerable<ContactViewModel>> GetAllContactsAsync();
        Task AddContactAsync(ContactFormViewModel model);
        Task<ContactFormViewModel> GetEditContactAsync(int id);
        Task EditContactAsync(int id, ContactFormViewModel model);
        Task <IEnumerable<ContactViewModel>> GetMyTeamAsync(string userId);
        Task AddToTeamAsync(string userId,int contactId);
        Task RemoveFromTeamAsync(string userId, int contactId);
    }
}
