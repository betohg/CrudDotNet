using Microsoft.EntityFrameworkCore;
using ProyectoFinalCruds.Models;

namespace ProyectoFinalCruds.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customers> customers { get; set; }
        public DbSet<Contacts> contacts { get; set; }
        public DbSet<Orders> orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>()
                .HasOne(o => o.Customer) 
                .WithMany() 
                .HasForeignKey(o => o.CUSTOMER_ID);
        }
    }
}
