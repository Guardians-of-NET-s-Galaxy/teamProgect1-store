using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Services.Interfaces;
using OnlineShop.Domain.DTOs.SiteSide.Account;
using OnlineShop.Domain.Entities.Users;

namespace Project_OnlineShop.Controllers
{
    public class AccountController : Controller
    {

        #region ctor

        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion


        #region register

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(UserRegisterDTO userRegisterDTO)
        {
            if(ModelState.IsValid)
            {
                var result = _userService.RegisterUser(userRegisterDTO);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["ErrorMessage"] = "کاربری با این شماره در سیستم ثبت شده است. لطفا وارد شوید";
            return View();
        }

        #endregion


        #region login

        public IActionResult Login()
        {
            return View();
        }

        #endregion

        #region logout

        #endregion
    }
}
