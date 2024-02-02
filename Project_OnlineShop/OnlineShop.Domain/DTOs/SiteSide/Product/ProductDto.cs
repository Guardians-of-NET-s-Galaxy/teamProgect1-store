using OnlineShop.Domain.DTOs.SiteSide.Category;
using OnlineShop.Domain.DTOs.SiteSide.Image;

namespace OnlineShop.Domain.DTOs.SiteSide.Product;

public class ProductDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    
    //RelationShip
    public int CategoryId { get; set; }
    public CategoryDto Category { get; set; }
    public ICollection<ImageDto> Images { get; set; }
}