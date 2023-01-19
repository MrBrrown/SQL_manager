using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vika_Automate.sakila;
using Vika_Automate.Services.RawMaterialRep;

namespace Vika_Automate.Pages.RawMaterialAdminPage
{
	public class RawMaterialAdminPageModel : PageModel
    {
        private readonly IRawMaterialRepository db;

        public IEnumerable<RawMaterial> RawMaterials { get; set; }
        public IEnumerable<Provider> Providers { get; set; }

        public RawMaterialAdminPageModel(IRawMaterialRepository db)
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
            RawMaterial rawMaterial = new RawMaterial()
            {
                IdRawMaterial = id,
                IdProvider = Int32.Parse(Request.Form["Provider"]),
                MaterialName = Request.Form["Name"],
                Volume = Int32.Parse(Request.Form["Volume"]),
                Price = Decimal.Parse(Request.Form["Price"])
            };

            db.Update(rawMaterial);

            return RedirectToPage();
        }

        public void OnGet()
        {
            RawMaterials = db.GetRawMaterials();
            Providers = db.GetProviders();
        }
    }
}
