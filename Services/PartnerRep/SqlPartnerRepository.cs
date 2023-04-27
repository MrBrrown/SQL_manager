using System;
using Microsoft.EntityFrameworkCore;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.PartnerRep
{
	public class SqlPartnerRepository : IPartnerRepository
	{
		private readonly new_databaseContext context;

		public SqlPartnerRepository(new_databaseContext context)
		{
			this.context = context;
		}

        public IEnumerable<Partner> GetPartners()
        {
            return context.Partners
                .Include(x => x.Advertisings);
        }

        public void Update(Partner partner)
        {
            var _partner = context.Partners.Attach(partner);
            _partner.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}

