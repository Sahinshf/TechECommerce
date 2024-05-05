using TechECommerce.Core.Models;
using TechECommerce.DataAccess.Persistance.Context.EfCore;
using TechECommerce.DataAccess.Repositories.Interface;

namespace TechECommerce.DataAccess.Repositories.Implementations;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    { }
}
