using System.Security.Claims;
using Contacts.Contracts;
using Contacts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactService contactService;

        public ContactsController(IContactService _contactService)
        {
            this.contactService = _contactService;
        }

        public async Task<IActionResult> All()
        {
            var contacts = await contactService.GetAllContactsAsync();
            return View(contacts);
        }

        public IActionResult Add()
        {
            var model = new ContactFormViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await contactService.AddContactAsync(model);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await contactService.GetEditContactAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await contactService.EditContactAsync(id, model);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Team()
        {
            var currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var models = await contactService.GetMyTeamAsync(currentUserId);

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(int id)
        {
            var currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await contactService.AddToTeamAsync(currentUserId, id);


            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int id)
        {
            var currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await contactService.RemoveFromTeamAsync(currentUserId, id);


            return RedirectToAction(nameof(Team));
        }
    }
}