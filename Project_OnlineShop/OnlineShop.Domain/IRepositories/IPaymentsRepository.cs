using OnlineShop.Domain.Entities.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.IRepositories
{
    public interface IPaymentsRepository
    {
        void AddPayment(Payment payment);
        void DeletePayment(Payment payment);
        void EditPayment(Payment payment);
        void SaveChanges();
    }
}
