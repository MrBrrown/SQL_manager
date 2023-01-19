using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vika_Automate.sakila;
using Vika_Automate.Services.EmploeeRep;

namespace Vika_Automate.Pages.EmploeeAdminPage
{
	public class EmploeeAdminPageModel : PageModel
    {
        private readonly IEmploeeRepository db;

        public IEnumerable<Employee> Employees;
        public IEnumerable<Product> Products;

        public EmploeeAdminPageModel(IEmploeeRepository db)
        {
            this.db = db;
        }

        public IActionResult OnPostReturn()
        {
            return RedirectToPage("/AdminList");
        }

        public IActionResult OnPostLog()
        {
            var login = Request.Form["Login"];
            var password = Request.Form["Password"];

            if (login == "admin" && password == "admin")
                return RedirectToPage("/AdminList");
            else
                return RedirectToPage("/Index");
        }

        public IActionResult OnPostUpdate(int IdEmp)
        {
            Employee employee = new Employee()
            {
                IdEmployee = IdEmp,
                IdProduct = Int32.Parse(Request.Form["Product"]),
                FioEmployee = Request.Form["Name"],
                JobTitle = Request.Form["JobTitle"],
                PhoneNumber = Request.Form["PhoneNumber"]
            };

            db.Update(employee);

            return RedirectToPage();
        }

        public void OnGet()
        {
            Employees = db.GetEmploees();
            Products = db.GetProducts();
        }
    }
}
