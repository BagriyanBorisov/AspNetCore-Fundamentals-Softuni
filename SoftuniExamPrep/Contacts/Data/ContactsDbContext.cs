using Contacts.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using static Contacts.Common.ModelsValidationConstants.ValidationConstants.UserValidations;

namespace Contacts.Data
{
    public class ContactsDbContext : IdentityDbContext<ApplicationUser>
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(u => u.UserName)
                .HasMaxLength(UserNameMaxLength)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(u => u.Email)
                .HasMaxLength(UserEmailMaxLength)
                .IsRequired();

            builder.Entity<ApplicationUserContact>()
                .HasKey(kvp => new { kvp.ContactId, kvp.ApplicationUserId });

            //builder
            //   .Entity<Contact>()
            //   .HasData(new Contact()
            //   {
            //       Id = 1,
            //       FirstName = "Bruce",
            //       LastName = "Wayne",
            //       PhoneNumber = "+359881223344",
            //       Address = "Gotham City",
            //       Email = "imbatman@batman.com",
            //       Website = "www.batman.com"
            //   });

        }
    }
}