using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cus in context.Customers
                             on r.CustomerId equals cus.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new RentalDetailDto { Id = r.Id, CompanyName = cus.CompanyName, CarName = c.CarName, BrandName = b.BrandName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
        }
    }
}
