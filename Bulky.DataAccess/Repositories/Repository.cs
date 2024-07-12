using System.Linq.Expressions;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext dbContext;
    private readonly DbSet<T> dbSet;
    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return dbSet.ToList();
    }

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        var entity = dbSet.FirstOrDefault(predicate);
        return entity;
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }


    public void RemoveRange(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
    }
}
