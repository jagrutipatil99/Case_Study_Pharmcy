using Microsoft.EntityFrameworkCore;

namespace Pharmax.Models
{
    public class PharmacyDbContext:DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options)
           : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<LoginDetails> LoginDetails { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected readonly IConfiguration Configuration;

        

    }
}
