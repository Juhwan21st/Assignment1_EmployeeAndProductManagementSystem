namespace JuhwanSeo_Assignment1.Repositories
{
	/// <summary>
	/// IUnitOfWork Interface
	/// </summary>
	public interface IUnitOfWork
	{
		// Access to Employee Repository
		IEmployeeRepository Employees { get; }
		// Access to Product Repository
		IProductRepository Products { get; }
		// Commit changes to the database
		int Complete();
	}
}
