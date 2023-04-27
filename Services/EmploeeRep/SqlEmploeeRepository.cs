using System;
using Microsoft.EntityFrameworkCore;
using Vika_Automate.sakila;

namespace Vika_Automate.Services.EmploeeRep
{
	public class SqlEmploeeRepository : IEmploeeRepository
	{
        private readonly new_databaseContext context;

		public SqlEmploeeRepository(new_databaseContext context)
		{
            this.context = context;
		}

        public IEnumerable<Employee> GetEmploees()
        {
            return context.Employees
                .Include(x => x.IdProductNavigation);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        public void Update(Employee employee)
        {
            var _employee = context.Employees.Attach(employee);
            _employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}

