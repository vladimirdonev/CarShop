using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Services.Cars
{
    public interface ICarService
    {
        public ICollection<AllCarsViewModel> GetCarsByUserId(string userId);

        public ICollection<AllCarsViewModel> AllCars();

        public void CreateCar(CreateCarViewModel createCarViewModel,string userId);

        public AllCarsViewModel GetCarByPlateNumber(string plateNumber);
    }
}
