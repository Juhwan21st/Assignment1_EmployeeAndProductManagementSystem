using JuhwanSeo_Assignment1.Models;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JuhwanSeo_Assignment1.Repositories
{
	/// <summary>
	/// Product Repository Interface
	/// Defines basic CRUD operations
	/// 
	/// Includes:
	///		C: Add Product
	///		R: Get All Products, Get Product By Id
	///		U: Update Product
	///		D: Delete Product
	/// </summary>
	public interface IProductRepository
	{

		IEnumerable<Product> GetAllProducts();
		Product GetProductById(int id);
		void AddProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(int id);
	}
}
