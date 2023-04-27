
using System;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.RawMaterialRep
{
	public interface IRawMaterialRepository
	{
		IEnumerable<RawMaterial> GetRawMaterials();

        IEnumerable<Provider> GetProviders();

        void Update(RawMaterial rawMaterial);
	}
}

