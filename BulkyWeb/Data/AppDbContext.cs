using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}
