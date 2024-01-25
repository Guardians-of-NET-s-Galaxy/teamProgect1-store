using OnlineShop.Domain.Entities.Categories;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Repositories
{
    public  class CategoriesRepository : ICategoriesRepository
    {
        private readonly ShopDbContext _shopDbContext;
        public CategoriesRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }   
        public void AddCategory(Category category) 
        {
            _shopDbContext.categories.Add(category);
            Savechange();
        }
        public void EditCategory(Category category) 
        {
            _shopDbContext.categories.Update(category);
            Savechange();
        }
        public void DeleteCategory(Category category) 
        {
            _shopDbContext.categories.Remove(category);
            Savechange();
        }
        public void Savechange() 
        {
            _shopDbContext.SaveChanges();
        }
    }
}
