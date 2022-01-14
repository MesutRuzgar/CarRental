﻿using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager=new CarManager(new InMemoryCarDal());
            
            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model " + car.Description+ " isimli aracı günlük " 
                    + car.DailyPrice+ " TL fiyat karşılığında kiralayabilirsiniz. "
                    );
            }
            
        }
    }
}
