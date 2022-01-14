using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
  public  interface ICarDal
    {
        List<Car> GetAll();
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);

        //Id unique olduğu için void yerine class ismiyle imzalıyoruz.
        //List yazsaydık 1 Id'li araba 1 tane olduğundan sadece 1 adet görünecekti.
        //sürekli 1 i döndürmemesi için list yerine class ismiyle imzaladık.
        Car GetById(int id);
    }
}
