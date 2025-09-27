using JuhwanSeo_Assignment1.Data;
using JuhwanSeo_Assignment1.Models;

namespace JuhwanSeo_Assignment1.Repositories
{
	/// <summary>
	/// Product Repository Implementation
	/// Inherits IProductRepository
	/// </summary>
	public class ProductRepository : IProductRepository
	{
		// AppDbContext instance
		private readonly AppDbContext _appDbContext;

		// Constructor with DbContext injection
		public ProductRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		// Get all products
		public IEnumerable<Product> GetAllProducts()
		{
			return _appDbContext.Products.ToList();
		}

		// Get product by Id
		public Product GetProductById(int id)
		{
			return _appDbContext.Products.Find(id);
		}

		// Add new product
		public void AddProduct(Product product)
		{
			_appDbContext.Products.Add(product);
		}

		// Update existing product
		public void UpdateProduct(Product product)
		{
			_appDbContext.Products.Update(product);
		}

		// Delete product by Id
		public void DeleteProduct(int id)
		{
			var product = _appDbContext.Products.Find(id);
			if (product != null)
			{
				_appDbContext.Products.Remove(product);
			}
		}
	}
}
