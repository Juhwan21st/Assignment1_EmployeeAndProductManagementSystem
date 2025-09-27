using JuhwanSeo_Assignment1.Data;

namespace JuhwanSeo_Assignment1.Repositories
{
	/// <summary>
	/// Unit of Work Implementation
	/// Provides access to Employee and Product Repositories
	/// Implements Complete method to save changes to the database
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		// AppDbContext instance
		private readonly AppDbContext _appDbContext;

		// Constructor with DbContext and Repositories injection
		public UnitOfWork(AppDbContext appDbContext, IEmployeeRepository employeeRepository, IProductRepository productRepository)
		{
			// inject DbContext and Repositories
			_appDbContext = appDbContext;
			Employees = employeeRepository;
			Products = productRepository;
		}

		// Access to Employee Repository
		public IEmployeeRepository Employees { get; set; }
		// Access to Product Repository
		public IProductRepository Products { get; set; }

		// Commit changes to the database
		public int Complete()
		{
			return _appDbContext.SaveChanges();
		}
	}
}
