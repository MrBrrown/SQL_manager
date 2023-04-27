using System;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.PartnerRep
{
	public interface IPartnerRepository
	{
		IEnumerable<Partner> GetPartners();

		void Update(Partner partner);
	}
}

