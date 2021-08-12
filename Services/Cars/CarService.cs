using AutoMapper;
using CarShop.Data;
using CarShop.Models;
using CarShop.ViewModels.Cars;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Services.Cars
{
    public class CarService : ICarService
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public CarService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public ICollection<AllCarsViewModel> AllCars()
        {
            var cars = this.db.Cars.ToList();
            var carViewModels = new List<AllCarsViewModel>();

            foreach (var car in cars)
            {
                this.db.Entry(car).Collection(x => x.Issues).Load();
                var carDTO = new AllCarsViewModel();
                carDTO = this.mapper.Map<Car, AllCarsViewModel>(car);
                carDTO.RemainingIssuesCount = car.Issues.Where(x => x.IsFixed == false).Count();
                carDTO.FixedIssuesCount = car.Issues.Where(x => x.IsFixed == true).Count();
                carViewModels.Add(carDTO);
            }

            return carViewModels;
        }

        public ICollection<AllCarsViewModel> GetCarsByUserId(string userId)
        {
            var cars = this.db.Cars.Where(x => x.OwnerId == userId).ToList();            
            var carViewModels = new List<AllCarsViewModel>();

            foreach (var car in cars)
            {
                this.db.Entry(car).Collection(x => x.Issues).Load();
                var carDTO = new AllCarsViewModel();
                carDTO = this.mapper.Map<Car, AllCarsViewModel>(car);
                carDTO.RemainingIssuesCount = car.Issues.Where(x => x.IsFixed == false).Count();
                carDTO.FixedIssuesCount = car.Issues.Where(x => x.IsFixed == true).Count();
                carViewModels.Add(carDTO);
            }

            return carViewModels;
        }

        public void CreateCar(CreateCarViewModel createCarViewModel,string userId)
        {
            var car = new Car();
            car = this.mapper.Map<CreateCarViewModel, Car>(createCarViewModel);
            car.OwnerId = userId;
            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public AllCarsViewModel GetCarByPlateNumber(string plateNumber)
        {
            var car = this.db.Cars.Where(x => x.PlateNumber == plateNumber).FirstOrDefault();

            if (car == null)
            {
                return null;
            }

            this.db.Entry(car).Collection(x => x.Issues).Load();
            var carDTO = new AllCarsViewModel();
            carDTO = this.mapper.Map<Car, AllCarsViewModel>(car);
            carDTO.RemainingIssuesCount = car.Issues.Where(x => x.IsFixed == false).Count();
            carDTO.FixedIssuesCount = car.Issues.Where(x => x.IsFixed == true).Count();

            return carDTO;
        }
    }
}
