using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Domain.Entities.Order;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public string ShippingAddress { get; set; }
    public decimal TotalPrice => OrderItems.Sum(item => item.Subtotal);
    
    //RelationShip
    
    public long UserId { get; set; }
    public User User { get; set; }
    
    
}