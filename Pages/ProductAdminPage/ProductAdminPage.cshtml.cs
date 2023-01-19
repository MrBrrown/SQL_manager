using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vika_Automate.sakila;
using Vika_Automate.Services.ProductRep;

namespace Vika_Automate.Pages.ProductAdminPage
{
	public class ProductAdminPageModel : PageModel
    {
        private readonly IProductRepository db;

        public IEnumerable<Product> Products { get; set; }

        public ProductAdminPageModel(IProductRepository db)
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

        public IActionResult OnPostUpdate(int id)
        {
            Product product = new Product()
            {
                IdProduct = id,
                VendorCode = Request.Form["Code"],
                Price = Decimal.Parse(Request.Form["Price"]),
                Manufacturer = Request.Form["Man"],
                ProductName = Request.Form["Name"]

            };

            db.Update(product);

            return RedirectToPage();
        }

        public void OnGet()
        {
            Products = db.GetProducts();
        }
    }
}
