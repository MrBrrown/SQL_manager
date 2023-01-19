using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vika_Automate.sakila;
using Vika_Automate.Services.AdvertisingRep;

namespace Vika_Automate.Pages.AdvertisingAdminPage
{
	public class AdvertisitgAdminPageModel : PageModel
    {
        private readonly IAdvertisingRepository db;

        public IEnumerable<Advertising> Advertisings { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Partner> Partners { get; set; }

        public AdvertisitgAdminPageModel(IAdvertisingRepository db)
        {
            this.db = db;
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

        public IActionResult OnPostReturn()
        {
            return RedirectToPage("/AdminList");
        }

        public IActionResult OnPostUpdate(int idAd)
        {
            Advertising advertising = new Advertising()
            {
                IdAdvertising = idAd,
                IdPartner = Int32.Parse(Request.Form["Partner"]),
                IdProduct = Int32.Parse(Request.Form["Product"]),
                Price = Decimal.Parse(Request.Form["Price"]),
                AdFormat = Request.Form["Format"]
            };

            db.Update(advertising);

            return RedirectToPage();
        }

        public void OnGet()
        {
            Advertisings = db.GetAdvertisings();
            Advertisings = Advertisings.OrderBy(x => x.AdFormat);
            Products = db.GetProducts();
            Partners = db.GetPartners();
        }
    }
}
