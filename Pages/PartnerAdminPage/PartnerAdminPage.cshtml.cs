using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vika_Automate.sakila;
using Vika_Automate.Services.PartnerRep;

namespace Vika_Automate.Pages.PartnerAdminPage
{
	public class PartnerAdminPageModel : PageModel
    {
        private readonly IPartnerRepository db;

        public IEnumerable<Partner> Partenrs;

        public PartnerAdminPageModel(IPartnerRepository db)
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
            Partner partner = new Partner()
            {
                IdPartner = id,
                FioPartner = Request.Form["Name"],
                PhoneNumber = Request.Form["PhoneNumber"]
            };

            db.Update(partner);

            return RedirectToPage();
        }

        public void OnGet()
        {
            Partenrs = db.GetPartners();
        }
    }
}
