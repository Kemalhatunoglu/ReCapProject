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

            //CarManager carManager = new CarManager(new EfCarDal());

            //var carsById = carManager.GetCarsByBradId(1);

            //Console.WriteLine(carsById.Count());

            //foreach (var carDetail in carManager.GetCarDetials())
            //{
            //    Console.WriteLine($"Sizin arabalarınız. Adı:{carDetail.CarName} Modeli:{carDetail.BrandName} Rengi: {carDetail.ColorName} Fiyatı: {carDetail.DailyPrice} almak istermisiniz.");
            //}

            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car
            {
                CarId=6,
                BrandId=1,
                CarName="kemal",
                ColorId = 1,
                DailyPrice = 100000,
                Description ="kemal",
                ModelYear = 2020
            });

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
