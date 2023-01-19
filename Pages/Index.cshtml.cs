using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vika_Automate.sakila;
using Vika_Automate.Services.ProductRep;

namespace Vika_Automate.Pages;

public class IndexModel : PageModel
{
    private readonly IProductRepository db;

    public IEnumerable<Product> Products { get; set; }

    public IndexModel(IProductRepository db)
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

    public void OnGet()
    {
        Products = db.GetProducts();
    }
}

