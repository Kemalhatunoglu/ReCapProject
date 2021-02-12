﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : IRepositoryService<Car>, ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car entity)
        {
            int dailyPrice = 100000;
            if (entity.DailyPrice > dailyPrice)
            {
                _carDal.Add(entity);
                return new SuccessResult(Message.CarAdded);
            }
            else
            {
                return new ErrorResult($"{Message.CarDailyPriceInvalid}, Daily Price:{dailyPrice}");
            }
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Message.CarDeleted);
        }

        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<Car>(_carDal.Get(filter));
        }

        public IResult Update(Car entity)
        {
            if (entity.ModelYear > 2021)
            {
                List<Car> carUpdate = _carDal.GetAll();
                foreach (var car in carUpdate)
                {
                    if (car.ModelYear == 2021)
                    {
                        return new ErrorResult(Message.CarUpdateInvalid);
                    }
                }
            }

            _carDal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetCarsByBradId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.ColorId == id));
        }

        public IDataResult<List<CarDetialDto>> GetCarDetials()
        {
            return new SuccessDataResult<List<CarDetialDto>>(_carDal.GetCarDetials());
        }

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
    }
}