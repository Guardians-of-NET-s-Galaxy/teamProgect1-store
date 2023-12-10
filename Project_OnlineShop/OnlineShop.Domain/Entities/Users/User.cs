using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.Users
{
    public class User
    {
        public long Id { get; set; }
        //public string UserName { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        
        //public ICollection<UserInRole > UserInRoles { get; set; }

    }
}
