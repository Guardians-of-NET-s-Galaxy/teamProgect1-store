using System;
using OnlineShop.Domain.Entities.Products;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.IRepositories
{
    public interface IProductsRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void EditProduct(Product product);
        void SaveChange();
    }
}
