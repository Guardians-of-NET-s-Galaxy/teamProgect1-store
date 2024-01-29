using OnlineShop.Domain.Entities.Payments;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Repositories
{
    internal class PaymentsRepository : IPaymentsRepository
    {
        private readonly ShopDbContext _shopDbContext;

        public PaymentsRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public void AddPayment(Payment payment) 
        {
            _shopDbContext.payments.Add(payment);
            SaveChanges();
        }
        public void EditPayment(Payment payment) 
        { 
            _shopDbContext.payments.Update(payment);
            SaveChanges();
        }
        public void DeletePayment(Payment payment) 
        {
            _shopDbContext.payments.Remove(payment);
            SaveChanges();

        }
        public void SaveChanges() 
        {
            _shopDbContext.SaveChanges();
        }

    }
}
