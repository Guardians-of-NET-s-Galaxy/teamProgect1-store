using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAct.Domain;

namespace OnlineShop.Domain.Entities.Basket
{
    [Auditable]
    public class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; private set; }

        private readonly List<BasketItem> _items = new List<BasketItem>();
        public ICollection<BasketItem> Item => _items.AsReadOnly();

        public Basket(string buyerId)
        {
            this.BuyerId = buyerId;
        }
    }

    [Auditable]
    public class BasketItem
    {
        public int Id { get; set; }
        public int UnitPrice { get; private set; }
        public int Quantity { get; private set; }

        public int BasketId { get; private set; }

        public BasketItem(int quantity, int unitPrice)
        {
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }


    }
}
