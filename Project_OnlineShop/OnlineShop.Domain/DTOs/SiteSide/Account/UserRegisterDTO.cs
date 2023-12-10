using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.DTOs.SiteSide.Account
{
    public class UserRegisterDTO
    {
        //public string UserName { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = "کلمه عبور و تکرار آن یکسان نیستند")]
        public string Repassword { get; set; }
    }
}
