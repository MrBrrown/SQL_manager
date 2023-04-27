using System;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.ProductionRep
{
	public interface IProductionRepository
	{
		IEnumerable<Production> GetProductions();

		IEnumerable<Product> GetProducts();

		IEnumerable<RawMaterial> GetRawMaterials();

		IEnumerable<Provider> GetProviders();

		void Update(Production production);
	}
}

