using System;
using Microsoft.EntityFrameworkCore;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.AdvertisingRep
{
	public class SqlAdvertisingRepository : IAdvertisingRepository
	{
        private readonly new_databaseContext context;

        public SqlAdvertisingRepository(new_databaseContext context)
		{
            this.context = context;
        }

        public IEnumerable<Advertising> GetAdvertisings()
        {
            return context.Advertisings
                .Include(x => x.IdPartnerNavigation)
                .Include(x => x.IdProductNavigation);
        }

        public IEnumerable<Partner> GetPartners()
        {
            return context.Partners;
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        public void Update(Advertising advertising)
        {
            var entity = context.Advertisings.Attach(advertising);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}

