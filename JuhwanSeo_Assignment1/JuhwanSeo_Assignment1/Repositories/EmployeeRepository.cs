using JuhwanSeo_Assignment1.Data;
using JuhwanSeo_Assignment1.Models;

namespace JuhwanSeo_Assignment1.Repositories
{
	/// <summary>
	/// Employee Repository Implementation
	/// Inherits IEmployeeRepository
	/// </summary>
	public class EmployeeRepository : IEmployeeRepository
	{
		// AppDbContext instance
		private readonly AppDbContext _appDbContext;

		// Constructor with DbContext injection
		public EmployeeRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		// Get all employees
		public IEnumerable<Employee> GetAllEmployees()
		{
			return _appDbContext.Employees.ToList();
		}

		// Get employee by Id
		public Employee GetEmployeeById(int id)
		{
			return _appDbContext.Employees.Find(id);
		}

		// Add new employee
		public void AddEmployee(Employee employee)
		{
			_appDbContext.Employees.Add(employee);
		}

		// Update existing employee
		public void UpdateEmployee(Employee employee)
		{
			_appDbContext.Employees.Update(employee);
		}

		// Delete employee by Id
		public void DeleteEmployee(int id)
		{
			var employee = _appDbContext.Employees.Find(id);
			if (employee != null)
			{
				_appDbContext.Employees.Remove(employee);
			}
		}
	}
}