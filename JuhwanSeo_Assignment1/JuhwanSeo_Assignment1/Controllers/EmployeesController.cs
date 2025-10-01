using JuhwanSeo_Assignment1.Models;
using JuhwanSeo_Assignment1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JuhwanSeo_Assignment1.Controllers
{
	/*	Product APIs:
• • GET /api/products → List all products
• • GET /api/products/{id
} → Get product by Id
• • POST /api/products → Create new product
• • PUT / api / products /{ id} → Update product
• • DELETE /api/products/{id} → Delete product*/
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		// IUnitOfWork instance
		private readonly IUnitOfWork _unitOfWork;

		// Constructor with UnitOfWork injection
		public EmployeesController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: api/employees
		[HttpGet]
		public ActionResult<IEnumerable<Employee>> GetAllEmployees()
		{
			// Store the list of employees retrieved from the repository
			var employees = _unitOfWork.Employees.GetAllEmployees();

			// Return the list of employees and HTTP 200 OK status
			return Ok(employees);
		}

		// GET: api/employees/{id}
		[HttpGet("{id}")]
		// if the controller uses [ApiController] attribute, there is no need to specify bounding source attributes like [FromRoute], but it can be good for clarity.
		// web reference: https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0#binding-source-parameter-inference
		public ActionResult GetById([FromRoute] int id)
		{
			var employee = _unitOfWork.Employees.GetEmployeeById(id);
			if (employee == null)
			{
				// return HTTP 404 Not Found if the employee does not exist
				return NotFound();
			}
			// return the employee and HTTP 200 OK status
			return Ok(employee);
		}

		// POST: api/employees
		[HttpPost]
		public ActionResult CreateEmployee([FromBody] Employee employee)
		{
			if (employee == null)
			{
				// return HTTP 400 Bad Request if the employee is null
				return BadRequest();
			}
			_unitOfWork.Employees.AddEmployee(employee);
			_unitOfWork.Complete();
			// return HTTP 201 Created status with the location of the new employee
			return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
		}

		// PUT: api/employees/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateEmployee([FromRoute] int id, [FromBody] Employee employee)
		{
			var existingEmployee = _unitOfWork.Employees.GetEmployeeById(id);

			if (existingEmployee == null)
			{
				// return HTTP 404 Not Found if the employee does not exist
				return NotFound();
			}
			// Update the existing employee's properties
			existingEmployee.Name = employee.Name;
			existingEmployee.Department = employee.Department;
			_unitOfWork.Employees.UpdateEmployee(existingEmployee);
			_unitOfWork.Complete();

			// return the updated employee and HTTP 200 OK status
			return Ok(existingEmployee);
		}

		// DELETE: api/employees/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteEmployee([FromRoute] int id)
		{
			var existingEmployee = _unitOfWork.Employees.GetEmployeeById(id);
			if (existingEmployee == null)
			{
				// return HTTP 404 Not Found if the employee does not exist
				return NotFound();
			}
			_unitOfWork.Employees.DeleteEmployee(id);
			_unitOfWork.Complete();

			// return HTTP 200 OK status
			return Ok(new { message = "Employee deleted successfully." });
		}
	}
}
