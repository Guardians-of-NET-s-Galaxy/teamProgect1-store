using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Services.Interfaces;
using OnlineShop.Domain.DTOs.SiteSide.Account;

namespace Project_OnlineShop.Controllers
{
    public class AccountController : Controller
    {

        #region ctor

        private readonly IUserService
        public AccountController()
        {
            
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }

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
                if(_context.Users.Any(p => p.Mobile==userRegisterDTO.Mobile.Trim() == false)
                {
                    User user = new User()
                    {
                        Mobile = userRegisterDTO.Mobile.Trim(),
                        Password = PasswordHelper.EncodePasswordMd5(userRegisterDTO.Password),
                        Username = userRegisterDTO.UserName
                    };

                    _context.Users.Add(user);
                    _context.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        #endregion


        #region ligin

        #endregion

        #region logout

        #endregion
    }
}
