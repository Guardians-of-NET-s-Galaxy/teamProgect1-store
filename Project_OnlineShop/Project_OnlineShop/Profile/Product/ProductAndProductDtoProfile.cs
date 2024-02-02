using OnlineShop.Domain.DTOs.SiteSide.Product;

namespace Project_OnlineShop.Profile.Product;

public class ProductAndProductDtoProfile : AutoMapper.Profile
{
    public ProductAndProductDtoProfile()
    {
        CreateMap<OnlineShop.Domain.Entities.Products.Product, ProductDto>().ReverseMap();
    }
}