using OnlineShop.Domain.DTOs.SiteSide.Account;
using OnlineShop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.IRepositories
{
    public interface IUserRepository
    {
        bool ExistUserByMobile(string mobile);

        void AddUser(User user);

        User ValidUserForLogin(UserLoginDTO userLoginDTO);

        void SaveChanges();
    }
}
