using OnlineShop.Application.Services.Interfaces;
using OnlineShop.Domain.DTOs.Base;
using OnlineShop.Domain.DTOs.SiteSide.Product;
using OnlineShop.Domain.IRepositories;

namespace OnlineShop.Application.Services.Implementations;

public class ProductService : IProductService
{
    
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    public Task<Response<IEnumerable<ProductDto>>> GetAllProductAsync(int page, int pageSize, string search)
    {
        var response = _repository.GetAllProductAsync(page, pageSize, search);
        return response;
    }

    public Task<Response<ProductDto>> GetProductByIdAsync(int id)
    {
        var response = _repository.GetProductByIdAsync(id);
        return response;
    }

    public Task<Response<bool>> CreateProductAsync(ProductDto _product)
    {
        var response = _repository.CreateProductAsync(_product);
        return response;
    }

    public Task<Response<bool>> DeleteProductAsync(int id)
    {
        var response = _repository.DeleteProductAsync(id);
        return response;
    }

    public Task<Response<ProductDto?>> UpdateProductAsync(ProductDto _product)
    {
        var response = _repository.UpdateProductAsync(_product);
        return response;
    }
}