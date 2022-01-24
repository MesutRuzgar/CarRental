using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join cus in context.Customers on r.CustomerId equals cus.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join u in context.Users on cus.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                CarName=b.BrandName + " "+ c.CarName,
                                CustomerName=u.FirstName + " "+u.LastName,
                                DailyPrice=c.DailyPrice,
                                RentDate=r.RentDate,
                                ReturnDate=r.ReturnDate,
                                CarId=c.Id
                             };
                return result.ToList();
            }
        }
    }
}
