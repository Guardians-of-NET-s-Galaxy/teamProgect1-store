using OnlineShop.Domain.Entities.BaseEntities;
using OnlineShop.Domain.Entities.Products;
using System.ComponentModel.Design;

namespace OnlineShop.Domain.Entities.Cart;

public class CartItem : BaseEntity
{
    public long Id { get; set; }
    public virtual Product Product { get; set; }
    public long ProductId { get; set; }
    public virtual Cart Cart { get; set; }
    public long CartId { get; set; }


    public int Quantity { get; set; }
    public decimal Price { get; set; }

}