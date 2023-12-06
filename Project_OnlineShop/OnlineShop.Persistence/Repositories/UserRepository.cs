using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopDbContext _shopDbContext;
        public UserRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
    }
}
