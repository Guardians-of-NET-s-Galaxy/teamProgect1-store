using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.DTOs.Base;
using OnlineShop.Domain.DTOs.SiteSide.Product;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.AppDbContext;

namespace OnlineShop.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShopDbContext _shopDbContext;
    private readonly IMapper _mapper;
    public ProductRepository(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<Response<IEnumerable<ProductDto>>> GetAllProductAsync(int page, int pageSize, string? search = null)
    {
        var query = _shopDbContext.products
            .AsNoTracking()
            .Where(x => x.IsDelete == false);
        int totalCount;
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Name.Contains(search));
            
        }
        totalCount = query.Count();
        var Productlist = await query.Skip((page-1) * pageSize)
            .Take(pageSize)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        var data = new Response<IEnumerable<ProductDto>>(Productlist,totalCount);
        return data;

    }

    public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
    {
        var query = _shopDbContext.products
            .AsNoTracking()
            .Where(x => x.IsDelete == false);
        var Productlist = await query
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        
        return Productlist.ToList();

    }
    public async Task<Response<ProductDto>> GetProductByIdAsync(int id)
    {
        var Item = await _shopDbContext.products.AsNoTracking()
            .Where(x => x.IsDelete == false)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(p => p.Id == id);
        return new Response<ProductDto>(Item);
    }

    public async Task<Response<bool>> CreateProductAsync(ProductDto _product)
    {

        bool productExists = await _shopDbContext.products
            .AnyAsync(p => p.Name == _product.Name);

        if (!productExists)
        {
            var product = _mapper.Map<Product>(_product);

            _shopDbContext.products.Add(product);
            await _shopDbContext.SaveChangesAsync();
            
            return new Response<bool>(true,true,"Product successfully Created");
        }
        return new Response<bool>(false,true,"this product is Exist!");
       
    }

    public async Task<Response<bool>> DeleteProductAsync(int id)
    {
        var Item = await _shopDbContext.products
            .Where(x => x.IsDelete == false)
            .FirstOrDefaultAsync(p => p.Id == id);
        Item.IsDelete = true;
        Item.DeletionDate = DateTime.Now;
        await _shopDbContext.SaveChangesAsync();
        return new Response<bool>(true,true,"this product is deleted successfully");
    }


    public async Task<Response<ProductDto?>> UpdateProductAsync(ProductDto _product)
    {
        
        var Item = await _shopDbContext.products
            .Where(x => x.IsDelete == false)
            .FirstOrDefaultAsync(p => p.Id == _product.Id);
        if (Item != null)
        {
            _mapper.Map(_product, Item);
            await _shopDbContext.SaveChangesAsync();
            return new Response<ProductDto?>(_product);
        }
        
        return new Response<ProductDto?>(null,false,"this product dosn't Exist!");
        
    }
}