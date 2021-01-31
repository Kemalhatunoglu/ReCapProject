using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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
            int isExsist = _carDal.GetById(car);

            if (isExsist != 0)
            {
                Console.WriteLine("Var olan bir araba ekleyemezsiniz.");
            }
            _carDal.Add(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
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
