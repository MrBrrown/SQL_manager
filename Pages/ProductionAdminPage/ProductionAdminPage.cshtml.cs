using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vika_Automate.sakila;
using Vika_Automate.Services.ProductionRep;

namespace Vika_Automate.Pages.ProductionAdminPage
{
	public class ProductionAdminPageModel : PageModel
    {
        private readonly IProductionRepository db;

        public IEnumerable<Production> Productions;
        public IEnumerable<Product> Products;
        public IEnumerable<RawMaterial> RawMaterials;
        public IEnumerable<Provider> Providers;

        public ProductionAdminPageModel(IProductionRepository db)
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
            Production production = new Production()
            {
                IdProduction = id,
                IdProduct = Int32.Parse(Request.Form["Product"]),
                IdRawMaterial = Int32.Parse(Request.Form["Raw"]),
                IdProvider = Int32.Parse(Request.Form["Provider"]),
                NameProduction = Request.Form["Name"],
                ProductionCity = Request.Form["City"]
            };

            db.Update(production);

            return RedirectToPage();
        }

        public void OnGet()
        {
            Productions = db.GetProductions();
            Products = db.GetProducts();
            RawMaterials = db.GetRawMaterials();
            Providers = db.GetProviders();
        }
    }
}
