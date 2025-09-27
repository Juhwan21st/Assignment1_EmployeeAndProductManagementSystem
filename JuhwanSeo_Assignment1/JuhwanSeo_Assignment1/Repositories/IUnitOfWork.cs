namespace JuhwanSeo_Assignment1.Repositories
{
	public interface IUnitOfWork
	{
		IEmployeeRepository Employees { get; }
		IProductRepository Products { get; }
		int Complete();
	}
}
