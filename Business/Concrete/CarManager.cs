using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Arabanız başarı ile eklenmiştir.");
            }
            else
            {
                Console.WriteLine("Lütfen girdiğiniz değerin 0 dan daha büyük bir değer olmasına dikkat ediniz.");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            int brandCount = _carDal.GetAll(x => x.BrandId == id).Count();
            if (id > brandCount)
            {
                Console.WriteLine($"{id} sayısında bir modelimiz yoktur.");
            }
            return _carDal.GetCarsByBradId(id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetCarsByColorId(id);
        }

        public void Update(Car car)
        {
            if (car.ModelYear > 2021)
            {
                List<Car> carUpdate = _carDal.GetAll();
                foreach (var item in carUpdate)
                {
                    if (item.ModelYear == 2021)
                    {
                        Console.WriteLine("Tarihi bu günün tarihten ilerisine güncelleyemezsiniz.");
                    }
                }
            }

            _carDal.Update(car);
        }
    }
}
