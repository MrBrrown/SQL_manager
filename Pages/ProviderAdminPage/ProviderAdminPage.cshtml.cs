using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vika_Automate.sakila;
using Vika_Automate.Services.ProviderRep;

namespace Vika_Automate.Pages.ProviderAdminPage
{
	public class ProviderAdminPageModel : PageModel
    {
        private readonly IProviderRepository db;

        public IEnumerable<Provider> Providers { get; set; }

        public ProviderAdminPageModel(IProviderRepository db)
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
            Provider provider = new Provider()
            {
                IdProvider = id,
                CompanyName = Request.Form["CompName"],
                FioProvider = Request.Form["Name"],
                PhoneNumber = Request.Form["PhoneNumber"]
            };

            db.Update(provider);

            return RedirectToPage();
        }

        public void OnGet()
        {
            Providers = db.GetProviders();
        }
    }
}
