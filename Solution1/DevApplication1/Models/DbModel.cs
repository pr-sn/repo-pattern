using DevApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevApplication1.Models
{

   public class ProductDbContext: DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> option):base(option)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Product> Products { get; set; }
    }
}



