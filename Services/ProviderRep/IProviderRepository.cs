using System;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.ProviderRep
{
	public interface IProviderRepository
	{
		IEnumerable<Provider> GetProviders();

		void Update(Provider provider);
	}
}

