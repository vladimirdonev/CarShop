using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.ViewModels.Issues
{
    public class CreateIssueViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Description Must be At Least 5 Letters")]
        public string Description { get; set; }

        public string CarId { get; set; }
    }
}
