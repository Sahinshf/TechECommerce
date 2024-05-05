using TechECommerce.Core.Models.Common;
namespace TechECommerce.Core.Models;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string OperatingSystem { get; set; } = null!;
    public int Storage { get; set; }
    public decimal Price { get; set; }

}
