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
        public long OrderId { get; set; }
        public decimal ToTalPayment {get; set; }
    }
}
