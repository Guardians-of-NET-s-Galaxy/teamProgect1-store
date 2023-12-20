using OnlineShop.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.Categories
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        //RelationShip
        
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
