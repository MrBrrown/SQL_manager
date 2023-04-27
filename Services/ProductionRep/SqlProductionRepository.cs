using System;
using Microsoft.EntityFrameworkCore;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.ProductionRep
{
	public class SqlProductionRepository : IProductionRepository
	{
		private readonly new_databaseContext context;

		public SqlProductionRepository(new_databaseContext context)
		{
			this.context = context;
		}

        public IEnumerable<Production> GetProductions()
        {
            return context.Productions
                .Include(x => x.IdProductNavigation)
                .Include(x => x.IdRawMaterialNavigation)
                .Include(x => x.IdProviderNavigation);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        public IEnumerable<Provider> GetProviders()
        {
            return context.Providers;
        }

        public IEnumerable<RawMaterial> GetRawMaterials()
        {
            return context.RawMaterials;
        }

        public void Update(Production production)
        {
            var _production = context.Productions.Attach(production);
            _production.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}

