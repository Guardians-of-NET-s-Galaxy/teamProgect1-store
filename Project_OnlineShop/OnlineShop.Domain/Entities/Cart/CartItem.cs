using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Domain.Entities.Base;

namespace OnlineShop.Domain.Entities.Cart;

public class CartItem : BaseEntity
{
    [ForeignKey("Product")]
    public long ProductId { get; set; }
    public int Quantity { get; set; }
}