using JuhwanSeo_Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace JuhwanSeo_Assignment1.Data
{
	/// <summary>
	/// Application Database Context
	/// </summary>
	public class AppDbContext : DbContext
	{
		// DbSet for Employee and Product entities
		// DbSet is a collection representing a table in the database
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Product> Products { get; set; }


		// Constructor with DbContextOptions injection
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
	}
}
