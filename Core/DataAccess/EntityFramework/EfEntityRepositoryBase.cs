using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //CRUD İşlemlerimizi yaparken kullanabileceğimzi genel bir Core katmanı yazmış olduk
    // Bu Kodu bütün projelerimizde kullanabiliyoruz.
    //CarRental/Solution Explorer Sağ Tık / Add /Existing Project/ Core olan bir projemizin içindeki Core klasöründe Core.csproj dosyasını ekleyebiliriz. 
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);// Veri kaynağı ile ilişkilendir.
                addedEntity.State = EntityState.Added;// Ekleme işlemini yap
                context.SaveChanges();// Ve veri tabanına eklettik.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); // Veri kaynağı ile ilişkilendir.
                deletedEntity.State = EntityState.Deleted; // silme işlemini yap
                context.SaveChanges(); // Ve veri tabanına eklettik.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); // Veri kaynağı ile ilişkilendir.
                updatedEntity.State = EntityState.Modified; // güncelleme işlemini yap
                context.SaveChanges(); // Ve veri tabanına eklettik.
            }
        }
    }
}
