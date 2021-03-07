using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(CarValidator))] // Aspect ekleddik AOP desenini ekliyoruz.
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckModelYearIsValid(car));
            _carDal.Add(car);
            return new SuccessResult(Message.CarAdded);
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

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run(CheckModelYearIsValid(car));
            _carDal.Update(car);
            return new SuccessResult(Message.CarUpdate);
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

        [CacheAspect]
        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            //if (DateTime.Now.Hour == 13)
            //{
            //    return new ErrorDataResult<List<Car>>();
            //}

            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(x => x.CarId == id);
            return new SuccessDataResult<Car>(result);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            var result = _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
            return new SuccessDataResult<List<Car>>(result);
        }

        private IResult CheckModelYearIsValid(Car car)
        {
            var result = car.ModelYear;
            var dailyYear = DateTime.Now.Year;
            if (result > dailyYear)
            {
                return new ErrorResult(Message.CarDailyPriceInvalid);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }
    }
}