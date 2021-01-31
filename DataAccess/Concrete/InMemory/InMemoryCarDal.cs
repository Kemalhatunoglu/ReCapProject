using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car {CarId = 1,BrandId = 1,ColorId = 1,DailyPrice = 300.000,ModelYear = 2019,Description ="Güzel Araba"
                }, 
                new Car {CarId = 2,BrandId = 2,ColorId = 2,DailyPrice = 400.000,ModelYear = 2018,Description ="Güzel Araba"
                }, 
                new Car {CarId = 3,BrandId = 2,ColorId = 3,DailyPrice = 500.000,ModelYear = 2020,Description ="Güzel Araba"
                }, 
                new Car {CarId = 4,BrandId = 3,ColorId = 4,DailyPrice = 500.000,ModelYear = 2019,Description ="Güzel Araba"
                }, 
                new Car {CarId = 5,BrandId = 4,ColorId = 3,DailyPrice = 700.000,ModelYear = 2021,Description ="Güzel Araba"
                }, 
                new Car {CarId = 6,BrandId = 4,ColorId = 2,DailyPrice = 200.000,ModelYear = 2017,Description ="Güzel Araba"
                }
            };
        }
        public void Add(Car car)
        {
            // _car list'ine gelen Car tipindeki car nesnesini ekliyorum.
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            // SingleOrDefault Tek bir öge döndürür bunun yerine FirstOrDefault da kullanılabilir. 
            Car carForDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(carForDelete);
        }

        public List<Car> GetAll()
        {
            return _car.ToList();
        }

        public int GetById(Car car)
        {
            Car getCar = _car.Find(x => x.CarId == car.CarId);
            return getCar.CarId;
        }

        public void Update(Car car)
        {
            Car carForUpdate = _car.FirstOrDefault(c => c.CarId == car.CarId);
            carForUpdate.BrandId = car.BrandId;
            carForUpdate.ColorId = car.ColorId;
            carForUpdate.DailyPrice = car.DailyPrice;
            carForUpdate.Description = car.Description;
            carForUpdate.ModelYear = car.ModelYear;
        }
    }
}
