using System;
using Microsoft.EntityFrameworkCore;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.ProviderRep
{
	public class SqlProviderRepository : IProviderRepository
	{
		private readonly new_databaseContext context;

		public SqlProviderRepository(new_databaseContext context)
		{
			this.context = context;
		}

        public IEnumerable<Provider> GetProviders()
        {
            return context.Providers
                .Include(x => x.Productions)
                .Include(x => x.RawMaterials);
        }

        public void Update(Provider provider)
        {
            var _provider = context.Providers.Attach(provider);
            _provider.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}

