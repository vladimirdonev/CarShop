using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels.UserRoles
{
    public class RoleInputModel
    {
        [Required]
        [MinLength(5)]
        public string RoleName { get; set; }
    }
}
