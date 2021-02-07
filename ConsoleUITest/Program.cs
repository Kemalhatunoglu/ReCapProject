using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUITest
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryTest();

            CarManager carManager = new CarManager(new EfCarDal());
         
            var carsById = carManager.GetCarsByBrandId(1);

            Console.WriteLine(carsById.Count());

        }

        //private static void InMemoryTest()
        //{
        //    // Sadece test amaclıdır.
        //    CarManager carManager = new CarManager(new InMemoryCarDal());

        //    Car car = new Car();
        //    car.CarId = 4;
        //    car.BrandId = 2;
        //    car.ColorId = 3;
        //    car.DailyPrice = 300000;
        //    car.Description = "Sağlam araba";
        //    car.ModelYear = 2024;

        //    carManager.Update(car);

        //    foreach (var item in carManager.GetAll())
        //    {
        //        Console.WriteLine(item.CarId);
        //    }
        ////}
    }
}
