using OnlineShop.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.IRepositories
{
    public interface ICategoriesRepository
    {
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        void EditCategory(Category category);
        void Savechange();
    }
}
