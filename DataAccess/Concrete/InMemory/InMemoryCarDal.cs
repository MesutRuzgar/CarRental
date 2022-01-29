using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2019, DailyPrice = 250, Description = "Ford Focus" },
                new Car { Id = 2, BrandId = 2, ColorId = 1, ModelYear = 2013, DailyPrice = 100, Description = "Renault Clio" },
                new Car { Id = 3, BrandId = 3, ColorId = 2, ModelYear = 2020, DailyPrice = 400, Description = "Mercedes-Benz C180" },
                new Car { Id = 4, BrandId = 4, ColorId = 3, ModelYear = 2015, DailyPrice = 200, Description= "Fiat Egea" },
                new Car { Id = 1, BrandId = 1, ColorId = 4, ModelYear = 2018, DailyPrice = 150, Description = "Ford Fiesta" }

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.Where(c=>c.Id==car.Id).SingleOrDefault();
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            //Id unique olduğu için class ismiyle imzalıyoruz.
            //List yazsaydık 1 Id'li araba 1 tane olduğundan sadece 1 adet görünecekti.
            //sürekli 1 i döndürmemesi için list yerine class ismiyle imzaladık.
            Car carToGetById = _cars.SingleOrDefault(c=>c.Id==id);
            return carToGetById;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsWithBrandIdAndColorId(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.Id==car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            
        }

       
    }
}
