using JuhwanSeo_Assignment1.Models;
using JuhwanSeo_Assignment1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JuhwanSeo_Assignment1.Controllers
{
	/// <summary>
	/// Products API Controller
	/// Handles CRUD operations for Product entities
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		// IUnitOfWork instance
		private readonly IUnitOfWork _unitOfWork;

		// Constructor with UnitOfWork injection
		public ProductsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: api/products
		[HttpGet]
		public ActionResult<IEnumerable<Product>> GetAllProducts()
		{
			// Store the list of products retrieved from the repository
			var products = _unitOfWork.Products.GetAllProducts();

			// Return the list of products and HTTP 200 OK status
			return Ok(products);
		}

		// GET: api/products/{id}
		[HttpGet("{id}")]
		// if the controller uses [ApiController] attribute, there is no need to specify bounding source attributes like [FromRoute], but it can be good for clarity.
		// web reference: https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0#binding-source-parameter-inference
		public ActionResult GetById([FromRoute] int id)
		{
			var product = _unitOfWork.Products.GetProductById(id);
			if (product == null)
			{
				// return HTTP 404 Not Found if the product does not exist
				return NotFound();
			}

			// return the product and HTTP 200 OK status
			return Ok(product);
		}

		// POST: api/products
		[HttpPost]
		public ActionResult CreateProduct([FromBody] Product product)
		{
			if (product == null)
			{
				// return HTTP 400 Bad Request if the product is null
				return BadRequest();
			}

			_unitOfWork.Products.AddProduct(product);
			_unitOfWork.Complete();

			// return HTTP 201 Created status
			// web reference: https://learn.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-8.0#asynchronous-action
			return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
		}

		// PUT: api/products/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateProduct([FromRoute] int id, [FromBody] Product product)
		{
			var existingProduct = _unitOfWork.Products.GetProductById(id);
			if (existingProduct == null)
			{
				// return HTTP 404 Not Found if the product does not exist
				return NotFound();
			}
			// Update the existing product's properties
			existingProduct.Name = product.Name;
			existingProduct.Price = product.Price;
			_unitOfWork.Products.UpdateProduct(existingProduct);
			_unitOfWork.Complete();

			// return the updated product and HTTP 200 OK status
			return Ok(existingProduct);
		}

		// DELETE: api/products/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteProduct([FromRoute] int id)
		{
			var existingProduct = _unitOfWork.Products.GetProductById(id);
			if (existingProduct == null)
			{
				// return HTTP 404 Not Found if the product does not exist
				return NotFound();
			}
			_unitOfWork.Products.DeleteProduct(id);
			_unitOfWork.Complete();

			// return HTTP 200 OK status
			return Ok(new { message = "Product deleted successfully." });
		}
	}
}
