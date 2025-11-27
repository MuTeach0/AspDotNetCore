using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M03.RazorPagesCRUD.Models;
using M03.RazorPagesCRUD.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace M03.RazorPagesCRUD.Pages.Products;

public class EditModel(ProductStore store) : PageModel
{
    [BindProperty]
    public Product Product { get; set; } = new();
    public IActionResult OnGet(Guid id)
    {
        var product = store.GetById(id);

        if (product is null)
            return NotFound();
        Product = product;

        return Page();
    }

    public IActionResult OnPost()
    {
        var updated = store.Update(Product);
        if (!updated)
            return NotFound();

        return RedirectToPage("Index");

    }
}