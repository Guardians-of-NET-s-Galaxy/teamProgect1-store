using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Domain.Entities.Order;

public class OrderItem
{
    public int OrderItemId { get; set; }
    public int Quantity { get; set; }
    public Decimal Price { get; set; }
    public decimal Subtotal => Quantity * Price;
    
    
    // Relationship
    [ForeignKey("Product")]
    public long ProductId { get; set; }
    public Product Product { get; set; }
}