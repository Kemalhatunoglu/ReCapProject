using Core.Utilities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : IRepositoryService<Car>
    {
        IDataResult<List<Car>> GetCarsByBradId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetialDto>> GetCarDetials();
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);

    }
}
