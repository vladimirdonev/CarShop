using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.ViewModels.UserRoles
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public bool IsSelected { get; set; }
    }
}
