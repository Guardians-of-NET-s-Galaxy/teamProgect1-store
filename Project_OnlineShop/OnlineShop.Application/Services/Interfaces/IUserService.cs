using OnlineShop.Domain.DTOs.SiteSide.Account;
using OnlineShop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Interfaces
{
    public interface IUserService
    {
        bool ExistUserByMobile(string mobile);
        User UserRegisterDTOToUserEntity(UserRegisterDTO userRegisterDTO);

        void AddUser(User user);

        bool RegisterUser(UserRegisterDTO userRegisterDTO);
        User LoginUser(UserLoginDTO userLoginDTO);
        User ValidUserForLogin(UserLoginDTO userLoginDTO);
        
    }
}
