using System;
using Microsoft.EntityFrameworkCore;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.ProductRep
{
	public class SqlProductRepository : IProductRepository
	{
		private readonly new_databaseContext context;

		public SqlProductRepository(new_databaseContext context)
		{
			this.context = context;
		}

        public IEnumerable<Product> GetProducts()
        {
            return context.Products
                .Include(x => x.Advertisings)
                .Include(x => x.Employees)
                .Include(x => x.Productions);
        }

        public void Update(Product product)
        {
            var _product = context.Products.Attach(product);
            _product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}

