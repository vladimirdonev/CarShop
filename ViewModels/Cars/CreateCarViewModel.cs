using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.ViewModels.Cars
{
    public class CreateCarViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Model Must be At Least 5 Letters")]
        [MaxLength(20, ErrorMessage = "Model Must not Еxceeds 20 Letters")]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public string PlateNumber { get; set; }
    }
}
