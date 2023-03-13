using Microsoft.EntityFrameworkCore;
using Contact_Management_Web_App.ViewModels;

namespace Contact_Management_Web_App.Data
{
    public class ApplicationDbContext:DbContext
    {
        //ApplicationDbContext provide a way to communicate with our database
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base (options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Contact_Management_Web_App.ViewModels.CreateUpdateContactViewModel> CreateUpdateContactViewModel { get; set; }
    }
}
