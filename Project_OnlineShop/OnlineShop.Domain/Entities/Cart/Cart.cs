using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Domain.Entities.Cart;

public class Cart
{
    
    // Relationship
    public long UserId { get; set; }
    public User User { get; set; }

    public List<CartItem> CartItems { get; set; } = new List<CartItem>();
}