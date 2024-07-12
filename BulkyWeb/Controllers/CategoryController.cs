using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;
public class CategoryController : Controller
{
    private readonly AppDbContext dbContext;

    public CategoryController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var categories = dbContext.Categories.ToList();
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
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
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

        Category? category = dbContext.Categories.Find(id);
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
            dbContext.Categories.Update(category);
            dbContext.SaveChanges();
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

        Category? category = dbContext.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        Category? category = dbContext.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }

        dbContext.Categories.Remove(category);
        dbContext.SaveChanges();
        TempData["success"] = "Category deleted successfully";

        return RedirectToAction("Index");
    }
}
