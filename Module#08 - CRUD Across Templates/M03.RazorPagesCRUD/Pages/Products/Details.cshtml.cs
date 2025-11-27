using M03.RazorPagesCRUD.Models;
using M03.RazorPagesCRUD.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace M03.RazorPagesCRUD.Pages.Products;

public class DetailsModel(ProductStore store) : PageModel
{
	public Product? Product { get; private set; }

    public IActionResult OnGet(Guid id) // {8d85d027-2ad0-4e21-9251-149a5add1c55}
    {
		Product = store.GetById(id);
		if (Product is null)
		{
			// Log the ID that wasn't found for debugging
			Console.WriteLine($"Product with ID {id} not found");
			// Also log all available IDs for debugging
			var allProducts = store.GetAll();
			Console.WriteLine("Available product IDs:");
			foreach (var product in allProducts)
			{
				Console.WriteLine($"- {product.Id} ({product.Name})");
			}
			return NotFound();
		}

		return Page();
	}
}