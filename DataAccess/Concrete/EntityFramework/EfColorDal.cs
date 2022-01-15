using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorsDal
    {
        public void Add(Colors entity)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var addedColor = context.Entry(entity);
                addedColor.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Colors entity)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Colors Get(Expression<Func<Colors, bool>> filter)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                return context.Set<Colors>().SingleOrDefault(filter);
            }
        }

        public List<Colors> GetAll(Expression<Func<Colors, bool>> filter = null)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                return filter == null
                    ? context.Set<Colors>().ToList()
                    : context.Set<Colors>().Where(filter).ToList();
            }
        }

        public void Update(Colors entity)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
