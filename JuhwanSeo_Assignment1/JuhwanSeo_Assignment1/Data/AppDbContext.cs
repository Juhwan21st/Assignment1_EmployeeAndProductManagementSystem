using JuhwanSeo_Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace JuhwanSeo_Assignment1.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }

		public DbSet<Product> Products { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		// Seed initial data
		// [Instruction] Pre-load at least 2 Employees and 2 Products into your in-memory database 
		/*protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().HasData(

				new Product { Id = 1, Name = "Product 1", Price = 100 },
				new Product { Id = 2, Name = "Product 2", Price = 1000 }

				);

			modelBuilder.Entity<Employee>().HasData(
				new Employee { Id = 1, Name = "Juhwan Seo", Department = "Development" },
				new Employee { Id = 2, Name = "Sangho Seo", Department = "Production" }
				);
		}*/
	}
}
