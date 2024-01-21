using OnlineShop.Domain.Entities.Users;
using OnlineShop.Domain.Entities.BaseEntities;

namespace OnlineShop.Domain.Entities.Cart;

public class Cart : BaseEntity
{
    public Guid BrowserId { get; set; }
    public bool Finished { get; set; }

    // Relationship
    public long? UserId { get; set; }
    public User User { get; set; }
    public ICollection<CartItem> CartItem { get; set; }

    //public List<CartItem> cartItems { get; set; } = new List<CartItem>();
}