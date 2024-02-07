using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.DTOs.SiteSide.Account;
using OnlineShop.Domain.Entities.Users;
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

        public bool ExistUserByMobile(string mobile)
        {
            return _shopDbContext.Users.Any(p => p.IsDeleted == false && p.Mobile == mobile);
        }

        public void AddUser(User user)
        {
            _shopDbContext.Users.Add(user);
            SaveChanges();
        }

        public void EditUser(User user)
        {
            _shopDbContext.Users.Update(user);
            SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _shopDbContext.Users.Remove(user);
            SaveChanges();
        }

        public User ValidUserForLogin(UserLoginDTO userLoginDTO)
        {
            return _shopDbContext.Users.FirstOrDefault(p => p.Mobile == userLoginDTO.Mobile && p.Password == userLoginDTO.Password);
        }

        public void SaveChanges()
        {
            _shopDbContext.SaveChanges();
        }

        public User FindUserByMobile(UserLoginDTO userLoginDTO)
        {
            return _shopDbContext.Users.FirstOrDefault(p => p.Mobile == userLoginDTO.Mobile && p.Password == userLoginDTO.Password);
        }

        public User FindUserToChangePassword(string mobile)
        {
            return _shopDbContext.Users.FirstOrDefault(p => p.Mobile == mobile);
        }
    }
}
