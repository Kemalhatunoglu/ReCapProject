using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUITest
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Car car = new Car();
            car.CarId = 4;
            car.BrandId = 2;
            car.ColorId = 3;
            car.DailyPrice = 300.000;
            car.Description = "Sağlam araba";
            car.ModelYear = 2024;

            carManager.Update(car);

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.CarId);
            }

        }
    }
}
