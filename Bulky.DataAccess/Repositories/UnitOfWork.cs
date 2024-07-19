using Bulky.DataAccess.Data;
using Bulky.DataAccess.IRepositories;

namespace Bulky.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext dbContext;
    public ICategoryRepository Category { get; private set; }
    public UnitOfWork(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        Category = new CategoryRepository(dbContext);
    }


    public void Save()
    {
        dbContext.SaveChanges();
    }
}
