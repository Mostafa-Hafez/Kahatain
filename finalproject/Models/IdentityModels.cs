using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace finalproject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Kahatain", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Admins> Admin { get; set; }
        public DbSet<Benefactor> benefactor { get; set; }
        public DbSet<Volunteer> volunteer { get; set; }
        public DbSet<Child> Child { get; set; }
        public DbSet<Dependant> Dependant { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Videos> Videos { get; set; }
        public DbSet<Sounds> Sounds { get; set; }
        public DbSet<Files> Files { get; set; }

    }
}