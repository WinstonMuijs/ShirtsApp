using Microsoft.EntityFrameworkCore;
using Shirts.Models;

namespace Shirts.Data
{
	// Representation of the DataBase
	public class ApplicationDbContext : DbContext
	{
        //connect to real DB, where the connectionstring is.
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }
		//Tabel(DbSet) with shirts
		public DbSet<Shirt> Shirts { get; set; }
        // Dev can config the DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // data seeding
            modelBuilder.Entity<Shirt>().HasData(
                new Shirt { ShirtId = 1, Brand = "Levy", Color = "Blue", Gender = "Men", Price = 99.95, Size = 9 },
                new Shirt { ShirtId = 2, Brand = "Gucci", Color = "Black", Gender = "Women", Price = 299.50, Size = 6 },
                new Shirt { ShirtId = 3, Brand = "Nike", Color = "Orange", Gender = "Men", Price = 59.98, Size = 8 }
            );
        }
    }
}

