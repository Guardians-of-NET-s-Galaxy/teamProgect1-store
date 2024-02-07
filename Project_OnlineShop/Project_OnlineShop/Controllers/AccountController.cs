using Azure.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Services.Interfaces;
using OnlineShop.Domain.DTOs.SiteSide.Account;
using OnlineShop.Domain.Entities.Users;
using System.Security.Claims;

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

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.LoginUser(userLoginDTO);
                if(user != null)
                {
                    var claims = new List<Claim>
                    {
                        new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new (ClaimTypes.MobilePhone, user.Mobile),
                        new (ClaimTypes.Name, user.FullName),
                    };

                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(claimIdentity);

                    var authProps = new AuthenticationProperties();
                    //authProps.IsPersistent = model.RememberMe;

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["ErrorMessage"] = "کاربری با این شماره در سیستم ثبت نشده است و یا رمز عبور صحیح نیست.";
            return View();
            
        }

        #endregion

        #region logout

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        #endregion

        #region password forget

        public IActionResult PasswordForget()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PasswordForget(string mobile)
        {
            var result = _userService.ExistUserByMobile(mobile);
            if (result == true)
            {
                TempData["passwordForgetMobile"] = mobile; // for sending to VerifyPhoneNumber
                return RedirectToAction("VerifyPhoneNumber", "Account");
            }
            TempData["ErrorMessage"] = "کاربری با این شماره در سیستم ثبت نشده است.";
            return View();
        }

        #endregion


        #region Verify Phone Number

        public IActionResult VerifyPhoneNumber()
        {
            string mobile = TempData.Peek("passwordForgetMobile") as string; // get mobile from PasswordForget
            ViewData["mobileNumber"] = mobile; // to send to view
            return View("VerifyPhoneNumber");
        }

        [HttpPost]
        public IActionResult VerifyPhoneNumber(int[] verifyCode)
        {
            var result = _userService.CheckVerifyCode(verifyCode);
            if (result == true)
            {
                return RedirectToAction("PasswordForgetChange", "Account");
            }
            TempData["ErrorMessage"] = "کد تایید صحیح نیست.";
            return View();
        }

        public IActionResult PasswordForgetChange()
        {
            string mobile = TempData["passwordForgetMobile"] as string; // get mobile from PasswordForget
            return View(); 
        }

        //[HttpPost, ValidateAntiForgeryToken]
        //public IActionResult PasswordForgetChange()
        //{
        //    string mobile = TempData["passwordForgetMobile"] as string; // get mobile from PasswordForget
        //    return View();
        //}


        #endregion
    }
}
