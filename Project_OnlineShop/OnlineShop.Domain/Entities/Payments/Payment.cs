using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.Payments
{
    public class Payment
    {
        public long Id { get; set; }
        public decimal ToTalPayment {get; set; }
        public string PaymentMethod { get; set; }
        
        // Relationship
        public int OrderId { get; set; }
        public Order.Order Order { get; set; }
    }
}
