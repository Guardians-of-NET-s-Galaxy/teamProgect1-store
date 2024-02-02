using OnlineShop.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Entities.Base;

namespace OnlineShop.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        
        
        //RelationShip
        public ICollection<Category> Categories { get; set; }
        public ICollection<Image.Image> Images { get; set; }
        
        
    }
}
