using Bulky.DataAccess.Data;
using Bulky.DataAccess.IRepositories;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;
public class CategoryController : Controller
{
    private readonly ICategoryRepository categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public IActionResult Index()
    {
        var categories = categoryRepository.GetAll().ToList();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            categoryRepository.Add(category);
            categoryRepository.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Edit(int? id)
    {
        if (id == null && id == 0)
        {
            return NotFound();
        }

        Category? category = categoryRepository.Get(c => c.Id == id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            categoryRepository.Update(category);
            categoryRepository.Save();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id == null && id == 0)
        {
            return NotFound();
        }

        Category? category = categoryRepository.Get(c => c.Id == id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        Category? category = categoryRepository.Get(c => c.Id == id);
        if (category == null)
        {
            return NotFound();
        }

        categoryRepository.Remove(category);
        categoryRepository.Save();
        TempData["success"] = "Category deleted successfully";

        return RedirectToAction("Index");
    }
}
