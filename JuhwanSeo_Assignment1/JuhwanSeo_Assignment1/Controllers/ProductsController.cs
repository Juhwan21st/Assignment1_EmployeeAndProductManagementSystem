using Microsoft.AspNetCore.Mvc;

namespace JuhwanSeo_Assignment1.Controllers
{   /*	Product APIs | 제품 API:

	GET /api/products → List all products | 모든 제품 목록 조회
	GET /api/products/{id
	} → Get product by Id | id로 제품 조회
	POST /api/products → Create new product | 새 제품 생성
	PUT /api/products/{id} → Update product | 제품 정보 수정
	DELETE /api/products/{id} → Delete product | 제품 삭제*/
	public class ProductsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
