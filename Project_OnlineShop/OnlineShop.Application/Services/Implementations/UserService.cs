﻿using OnlineShop.Application.Services.Interfaces;
using OnlineShop.Application.Utilities;
using OnlineShop.Domain.DTOs.SiteSide.Account;
using OnlineShop.Domain.Entities.Users;
using OnlineShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
