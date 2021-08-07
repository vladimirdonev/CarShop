using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels.UserRoles
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            this.Users = new HashSet<string>();
        }

        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        public HashSet<string> Users { get; set; }
    }
}
