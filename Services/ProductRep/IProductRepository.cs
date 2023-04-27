using System;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.ProductRep
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetProducts();

		void Update(Product product);
	}
}

