using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.ViewModels.Cars
{
    public class AllCarsViewModel
    {
        public string Id { get; set; }

        public string PictureUrl { get; set; }

        [Required]
        public string PlateNumber { get; set; }

        public int RemainingIssuesCount { get; set; }

        public int FixedIssuesCount { get; set; }
    }
}
