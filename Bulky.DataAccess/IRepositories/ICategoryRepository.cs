using Bulky.Models;

namespace Bulky.DataAccess.IRepositories;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category category);
}
