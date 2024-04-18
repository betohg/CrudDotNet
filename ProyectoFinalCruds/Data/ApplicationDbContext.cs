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
        public DbSet<Products> products { get; set; }
        public DbSet<Product_Categories> product_categories { get; set; }

        
    }
}
