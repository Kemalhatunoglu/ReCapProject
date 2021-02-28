using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            return new SuccessResult();
        }

        public IResult Delete(Rental entity)
        {
            return new SuccessResult();
        }

        public IDataResult<Rental> Get(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(filter));
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(filter));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>();
        }

        public IResult GetRentCar(int id)
        {
            var rentCar = _rentalDal.Get(x => x.RentalId == id);
            if (rentCar.ReturnDate == null)
            {
                //Console.WriteLine("Araba kiralanmaya uygundur.");
                return new SuccessResult(Message.CarRental);
            }
            else
            {
                return new ErrorResult(Message.CarNotRental);
            }
            
        }

        public IResult Update(Rental entity)
        {
            return new SuccessResult();
        }
    }
}
