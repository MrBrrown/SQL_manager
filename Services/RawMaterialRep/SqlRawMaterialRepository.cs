
using System;
using Microsoft.EntityFrameworkCore;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.RawMaterialRep
{
	public class SqlRawMaterialRepository : IRawMaterialRepository
	{
		private readonly new_databaseContext context;

		public SqlRawMaterialRepository(new_databaseContext context)
		{
			this.context = context;
		}

        public IEnumerable<Provider> GetProviders()
        {
            return context.Providers;
        }

        public IEnumerable<RawMaterial> GetRawMaterials()
        {
            return context.RawMaterials
                .Include(x => x.IdProviderNavigation);
        }

        public void Update(RawMaterial rawMaterial)
        {
            var _rawMaterial = context.RawMaterials.Attach(rawMaterial);
            _rawMaterial.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}

