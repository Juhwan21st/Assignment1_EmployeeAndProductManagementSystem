using JuhwanSeo_Assignment1.Models;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JuhwanSeo_Assignment1.Repositories
{
	/// <summary>
	///	 Employee Repository Interface
	///	 Defines basic CRUD operations
	///	 
	///	 Includes:
	///		C: Add Employee
	///		R: Get All Employees, Get Employee By Id
	///		U: Update Employee
	///		D: Delete Employee
	/// </summary>
	public interface IEmployeeRepository
	{
		IEnumerable<Employee> GetAllEmployees();
		Employee GetEmployeeById(int id);
		void AddEmployee(Employee employee);
		void UpdateEmployee(Employee employee);
		void DeleteEmployee(int id);
	}
}
