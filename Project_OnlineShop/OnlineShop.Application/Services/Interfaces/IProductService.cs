using OnlineShop.Domain.DTOs.Base;
using OnlineShop.Domain.DTOs.SiteSide.Product;

namespace OnlineShop.Application.Services.Interfaces;

public interface IProductService
{
    Task<Response<IEnumerable<ProductDto>>> GetAllProductAsync(int page, int pageSize, string search);
    Task<Response<ProductDto>> GetProductByIdAsync(int id);
    Task<Response<bool>> CreateProductAsync(ProductDto _product);
    Task<Response<bool>> DeleteProductAsync(int id);
    Task<Response<ProductDto?>> UpdateProductAsync(ProductDto _product);
}