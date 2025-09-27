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

	public class EmployeesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
