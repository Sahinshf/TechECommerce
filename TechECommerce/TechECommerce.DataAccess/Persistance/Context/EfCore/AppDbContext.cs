using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TechECommerce.Core.Models;

namespace TechECommerce.DataAccess.Persistance.Context.EfCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) :base(options)
    {    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
