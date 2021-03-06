using CarShop.Models;
using CarShop.Services.Cars;
using CarShop.ViewModels.Cars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private ICarService carService;
        private UserManager<IdentityUser> userManager;

        public CarsController(ICarService carService, UserManager<IdentityUser> userManager)
        {
            this.carService = carService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult All() 
        {
            if (this.User.IsInRole("Mechanic"))
            {
                return this.View(this.carService.AllCars());
            }
            var userId = this.userManager.GetUserId(this.User);
            var cars = this.carService.GetCarsByUserId(userId);
            return this.View(cars);
        }

        [HttpGet]
        public IActionResult Search(AllCarsViewModel carInput)
        {
            var car = this.carService.GetCarByPlateNumber(carInput.PlateNumber);
            if (car == null)
            {
                this.ModelState.AddModelError("PlateNumber", "Car With That PlateNumber Is Not Presented");
                return this.View(carInput);
            }
            return this.View(car);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCarViewModel createCarViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createCarViewModel);
            }
            var userId = this.userManager.GetUserId(this.User);
            this.carService.CreateCar(createCarViewModel,userId);
            return this.Redirect("/");
        }

    }
}
