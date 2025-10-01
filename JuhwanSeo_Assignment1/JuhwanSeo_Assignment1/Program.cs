using JuhwanSeo_Assignment1.Data;
using JuhwanSeo_Assignment1.Models;
using JuhwanSeo_Assignment1.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ----------------------------------
// Configure Entity Framework with In-Memory Database
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ManagementDb"));

// Register Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Register UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// ----------------------------------

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ----------------------------------
// Ensure the database is created when the application starts
using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
	dbContext.Database.EnsureCreated();

	// Check the environment and seed data accordingly
	if (app.Environment.IsDevelopment())
	{
		// Seed data for Development environment
		// dbContext.Employees = DbSet<Employee>
		// DbSet has methods like CRUD methods for it's table
		// web reference: https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1.addrange?view=efcore-8.0
		dbContext.Employees.AddRange(
			new Employee { Id = 1, Name = "Juhwan Seo", Department = "IT" },
			new Employee { Id = 2, Name = "Sangho Seo", Department = "HR" }
			);
		dbContext.Products.AddRange(
			new Product { Id = 1, Name = "Laptop", Price = 1350.50M },
			new Product { Id = 2, Name = "Keyboard", Price = 135.25M }
			);
	}
	else
	{
		// Seed data for Production environment
		dbContext.Employees.AddRange(
			new Employee { Id = 1, Name = "Eri Cho", Department = "IT" },
			new Employee { Id = 2, Name = "Yuhwan Seo", Department = "HR" }
		);
		dbContext.Products.AddRange(
			new Product { Id = 1, Name = "Notepad", Price = 3.20M },
			new Product { Id = 2, Name = "Tablet", Price = 185.99M }
		);
	}
	
	// Save changes to add seed data to the database
	dbContext.SaveChanges();
}
// ----------------------------------

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
