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
        [Range(5,20,ErrorMessage = "Model Must be Betwen 5 and 20 Letters")]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public string PlateNumber { get; set; }
    }
}
