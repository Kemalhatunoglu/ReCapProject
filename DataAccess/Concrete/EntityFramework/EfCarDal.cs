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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var carAdded = context.Entry(entity);
                carAdded.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var carDeleted = context.Entry(entity);
                carDeleted.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Car>().FirstOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

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

        public void Update(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var carUpdate = context.Entry(entity);
                carUpdate.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
