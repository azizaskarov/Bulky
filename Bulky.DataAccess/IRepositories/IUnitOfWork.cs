namespace Bulky.DataAccess.IRepositories;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }

    void Save();
}
