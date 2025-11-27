using M01.ModelAndInMemoryStoreSetup.Models;
using M01.ModelAndInMemoryStoreSetup.Store;
using Microsoft.AspNetCore.Mvc;

namespace M02.MVCCRUD.Controllers;

public class ProductsController(ProductStore store) : Controller
{
	// ../Products/index
	// ../Products

	[HttpGet]
	public IActionResult Index()
	{
		var products = store.GetAll();

		return View(products);
	}

	// ../Products/Details/{id}
	[HttpGet]
	public IActionResult Details(Guid id)
	{
		var product = store.GetById(id);

		if (product is null)
			return NotFound();

		return View(product);
	}

	// ../Products/Create
	[HttpGet]
	public IActionResult Create() => View();

	[HttpPost]
	public IActionResult Create(Product product)
	{
		product.Id = Guid.NewGuid();
		store.Add(product);
		return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public IActionResult Edit(Guid id)
	{
		var product = store.GetById(id);

		if (product is null)
			return NotFound();

		return View(product);
	}

	[HttpPost]
	public IActionResult Edit(Product product)
	{
		var success = store.Update(product);

		if (!success)
			return NotFound();

		return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public IActionResult Delete(Guid id)
	{
		var product = store.GetById(id);

		if (product is null)
			return NotFound();

		return View(product);
	}

	[HttpPost, ActionName("Delete")]
	public IActionResult DeleteConfirm(Guid id)
	{
		var product = store.GetById(id);

		if (product is null)
			return NotFound();
		store.Delete(product);
		return RedirectToAction(nameof(Index));
	}
}