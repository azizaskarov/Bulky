using System.Linq.Expressions;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.IRepositories;
using Bulky.Models;

namespace Bulky.DataAccess.Repositories;

public class CategoryRepository :Repository<Category>, ICategoryRepository
{
    private readonly AppDbContext dbContext;
    public CategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Save()
    {
        dbContext.SaveChanges();
    }

    public void Update(Category category)
    {
        dbContext.Update(category);
    }
}
