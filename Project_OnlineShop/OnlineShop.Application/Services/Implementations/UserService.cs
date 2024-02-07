using OnlineShop.Application.Services.Interfaces;
using OnlineShop.Application.Utilities;
using OnlineShop.Domain.DTOs.SiteSide.Account;
using OnlineShop.Domain.Entities.Users;
using OnlineShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XAct.Users;
using static System.Runtime.InteropServices.JavaScript.JSType;
using User = OnlineShop.Domain.Entities.Users.User;

namespace OnlineShop.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ExistUserByMobile(string mobile)
        {
            return _userRepository.ExistUserByMobile(mobile.Trim());
        }
        
        public User UserRegisterDTOToUserEntity(UserRegisterDTO userRegisterDTO)
        {
            User user = new User()
            {
                Mobile = userRegisterDTO.Mobile.Trim(),
                Password = PasswordHelper.EncodePasswordMd5(userRegisterDTO.Password),
                FullName = userRegisterDTO.FullName
                //UserName = userRegisterDTO.UserName
            };

            return user;
        }


        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public bool RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            // user existes?
            if (ExistUserByMobile(userRegisterDTO.Mobile))
            {
                return false;
            }

                // map
                var user = UserRegisterDTOToUserEntity(userRegisterDTO);

                // add user to database
                AddUser(user);

                return true;
        }

        public User? LoginUser(UserLoginDTO userLoginDTO)
        {
            //user exists?
            if(!ExistUserByMobile(userLoginDTO.Mobile))
            {
                return null;
            }

            var user = ValidUserForLogin(userLoginDTO);
            return user;

        }

        public User ValidUserForLogin(UserLoginDTO userLoginDTO)
        {
            UserLoginDTO loginUser = new()
            {
                Mobile = userLoginDTO.Mobile.Trim(),
                Password = PasswordHelper.EncodePasswordMd5(userLoginDTO.Password)
            };

            User user = _userRepository.ValidUserForLogin(loginUser);
            return user;
        }

        public bool CheckVerifyCode(int[] verifyCode)
        {
            int[] validVerifyCode = new int[] { 0, 0, 0, 0, 0 };
            var result = verifyCode.SequenceEqual(validVerifyCode);
            if (result == true)
            {
                return true;
            }
            else return false;
        }

        public User UserChangePasswordDTOToUserEntity(UserChangePasswordDTO userChangePasswordDTO)
        {
            var user = _userRepository.FindUserToChangePassword(userChangePasswordDTO.Mobile);
            return user;
        }

        public void ChangePassword(UserChangePasswordDTO userChangePasswordDTO)
        {
            var updatedUser = UserChangePasswordDTOToUserEntity(userChangePasswordDTO);
            updatedUser.Password = PasswordHelper.EncodePasswordMd5(userChangePasswordDTO.Password);
            _userRepository.EditUser(updatedUser);
        }
    }
}
