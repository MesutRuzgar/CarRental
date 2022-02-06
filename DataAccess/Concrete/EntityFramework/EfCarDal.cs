using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join k in context.Colors on c.ColorId equals k.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 ColorId = c.ColorId,
                                 BrandId = c.BrandId,
                                 ModelName = c.ModelName,
                                 BrandName = b.BrandName,
                                 ColorName = k.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 CarImage = (from i in context.CarImages
                                             where (c.Id == i.CarId)
                                             select new CarImage { Id = i.Id, CarId = c.Id, Date = i.Date, ImagePath = i.ImagePath }).ToList()
                             };
                return filter is null ? result.ToList() : result.Where(filter).ToList();

            }
        }

        public List<CarDetailDto> GetCarDetails(int brandId, int colorId)
        {
            var result = GetCarDetails().Where(c => c.BrandId == brandId && c.ColorId == colorId);
            return result.ToList();
        }
    }
}
