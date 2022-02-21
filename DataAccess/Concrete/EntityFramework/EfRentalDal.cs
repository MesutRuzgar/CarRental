using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetCheckRentDate(int carId, DateTime rentDate, DateTime? returnDate)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             where (r.CarId == carId)
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = r.CarId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }


        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
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
                                 CustomerId = cus.Id,
                                 UserId = u.Id,
                                 ModelName = c.ModelName,
                                 BrandName = b.BrandName,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 TotalAmount = r.TotalAmount,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CarId = c.Id,
                                 //TotalEarnings = (from ucret in context.Rentals select ucret.TotalAmount).Sum(),
                                 DailyPrice = c.DailyPrice,
                                 CarImage = (from i in context.CarImages
                                             where (c.Id == i.CarId)
                                             select new CarImage { Id = i.Id, CarId = c.Id, Date = i.Date, ImagePath = i.ImagePath }).ToList()
                             };
                return filter is null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public decimal TotalEarnings()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = (from r in context.Rentals select r.TotalAmount).Sum();
                return result;
            }

        }
    }
}
