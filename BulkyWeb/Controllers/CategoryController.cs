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
}
