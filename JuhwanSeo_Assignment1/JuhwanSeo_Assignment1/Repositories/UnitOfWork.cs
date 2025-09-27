using JuhwanSeo_Assignment1.Data;

namespace JuhwanSeo_Assignment1.Repositories
{
	public class UnitofWork : IUnitOfWork
	{
		private readonly AppDbContext _appDbContext;

		public UnitofWork(AppDbContext appDbContext, IEmployeeRepository employeeRepository, IProductRepository productRepository)
		{
			// inject DbContext and Repositories
			_appDbContext = appDbContext;

			Employees = employeeRepository;
			Products = productRepository;
		}

		public IEmployeeRepository Employees { get; set; }
		public IProductRepository Products { get; set; }

		public int Complete()
		{
			return _appDbContext.SaveChanges();
		}
	}
}
