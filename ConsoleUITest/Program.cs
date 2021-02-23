using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUITest
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAllCars();
            //GetAllBrandName();
            //GetCarsDailyPrice();
            //GetCarRental();

        }

        private static void GetCarRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetRentCar(10);

            Console.WriteLine(result);
        }

        private static void GetCarsDailyPrice()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> cars = carManager.GetByDailyPrice(300000, 350000).Data;

            foreach (var item in cars)
            {
                Console.WriteLine(item.CarName);
            }
        }

        private static void GetAllBrandName()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            List<Brand> brands = brandManager.GetAll().Data;

            foreach (var item in brands)
            {
                Console.WriteLine(item.BrandName);
            }
        }

        private static void GetAllCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            List<Car> cars = carManager.GetAll().Data;

            foreach (var item in cars)
            {
                Console.WriteLine(item.CarName);
            }
        }
    }
}
