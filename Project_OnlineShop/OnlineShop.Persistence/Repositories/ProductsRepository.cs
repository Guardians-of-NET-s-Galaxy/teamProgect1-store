using Microsoft.EntityFrameworkCore.Diagnostics;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ShopDbContext _shopDbContext;
        
        public ProductsRepository(ShopDbContext shopDbContext) 
        { 
            _shopDbContext = shopDbContext;
        }

        public void AddProduct(Product product) 
        { 
            _shopDbContext.products.Add(product);
            SaveChange();
            
        }
        public void EditProduct(Product product) 
        {
            _shopDbContext.products.Update(product);
            SaveChange();

        }
        public void DeleteProduct(Product product) 
        {
            _shopDbContext.products.Remove(product);
            SaveChange();
        }
        public void SaveChange() 
        {
            _shopDbContext.SaveChanges();
        }
   
    }
}
