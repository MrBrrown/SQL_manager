using System;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.EmploeeRep
{
	public interface IEmploeeRepository
	{
		IEnumerable<Employee> GetEmploees();

		IEnumerable<Product> GetProducts();

        void Update(Employee employee);
    }
}

