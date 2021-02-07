using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<Car> GetCarsByBradId(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Car>().Where(x => x.BrandId == id).ToList();
            }
        }

        public List<Car> GetCarsByColorId(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Car>().Where(x => x.ColorId == id).ToList();
            }
        }
    }
}
