using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CarShop.Models
{
    public class Car
    {
        public Car()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Issues = new List<Issue>();
        }

        public string Id { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string PictureUrl { get; set; }

        public string PlateNumber { get; set; }

        public string OwnerId { get; set; }

        public virtual IdentityUser Owner { get; set; }

        public virtual List<Issue> Issues { get; set; }
    }
}
