using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Vika_Automate.Pages
{
	public class AdminListModel : PageModel
    {
        public IActionResult OnPostLog()
        {
            var login = Request.Form["Login"];
            var password = Request.Form["Password"];

            if (login == "admin" && password == "admin")
                return RedirectToPage("/AdminList");
            else
                return RedirectToPage("/Index");
        }

        public void OnGet()
        {
        }
    }
}
