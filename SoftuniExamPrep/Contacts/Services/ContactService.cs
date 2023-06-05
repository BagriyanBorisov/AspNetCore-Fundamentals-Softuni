using Contacts.Contracts;
using Contacts.Data;
using Contacts.Data.Models;
using Contacts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Contacts.Services;

public class ContactService : IContactService
{
    private readonly ContactsDbContext dbContext;

    public ContactService(ContactsDbContext _dbContext)
    {
        dbContext = _dbContext;
    }

    public async Task<IEnumerable<ContactViewModel>> GetAllContactsAsync()
    {
        return await dbContext.Contacts
            .Select(c => new ContactViewModel
            {
                ContactId = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Website = c.Website
            })
            .ToListAsync();
    }

    public async Task AddContactAsync(ContactFormViewModel model)
    {
        var contact = new Contact
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Address = model.Address,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Website = model.Website
        };

        await dbContext.Contacts.AddAsync(contact);
        await dbContext.SaveChangesAsync();
    }

    public async Task<ContactFormViewModel> GetEditContactAsync(int id)
    {
        var contact = await dbContext.Contacts.FindAsync(id);

        if (contact == null) throw new ArgumentException("Could not find the contact to Edit.");

        return new ContactFormViewModel
        {
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Address = contact.Address,
            Email = contact.Email,
            PhoneNumber = contact.PhoneNumber,
            Website = contact.Website
        };
    }

    public async Task EditContactAsync(int id, ContactFormViewModel model)
    {
        var contact = await dbContext.Contacts.FindAsync(id);

        if (contact == null) throw new ArgumentException("Could not find the contact to Edit.");

        contact.FirstName = model.FirstName;
        contact.LastName = model.LastName;
        contact.Address = model.Address;
        contact.Email = model.Email;
        contact.PhoneNumber = model.PhoneNumber;
        contact.Website = model.Website;

        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ContactViewModel>> GetMyTeamAsync(string userId)
    {
        var user = await dbContext.Users.Where(u => u.Id == userId)
            .Include(u => u.ApplicationUsersContacts)
            .ThenInclude(ap => ap.Contact).FirstOrDefaultAsync();

        if (user == null) throw new ArgumentException("User Invalid ID");

        return user.ApplicationUsersContacts.Select(contact => new ContactViewModel
        {
            ContactId = contact.Contact.Id,
            FirstName = contact.Contact.FirstName,
            LastName = contact.Contact.LastName,
            Address = contact.Contact.Address,
            Email = contact.Contact.Email,
            PhoneNumber = contact.Contact.PhoneNumber,
            Website = contact.Contact.Website
        });

    }

    public async Task AddToTeamAsync(string userId, int contactId)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        var contact = await dbContext.Contacts.FirstOrDefaultAsync(u => u.Id == contactId);

        if (contact == null) throw new ArgumentException("Invalid Contact ID");

        if (user == null || user.ApplicationUsersContacts.Any(ap => ap.ContactId == contact.Id))
        {
            return;
        }

        user.ApplicationUsersContacts.Add(new ApplicationUserContact()
        {
            ApplicationUserId = user.Id,
            ContactId = contact.Id,
            ApplicationUser =user,
            Contact = contact

        });

        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveFromTeamAsync(string userId, int contactId)
    {
        var user = await dbContext.Users.Where(u => u.Id == userId)
            .Include(u => u.ApplicationUsersContacts)
            .ThenInclude(ap => ap.Contact).FirstOrDefaultAsync();

        if (user == null) throw new ArgumentException("User Invalid ID");

        var contact = user.ApplicationUsersContacts.FirstOrDefault(c => c.ContactId == contactId);

        if (contact != null)
        {
            user.ApplicationUsersContacts.Remove(contact);
            await dbContext.SaveChangesAsync();
        }
    }
}