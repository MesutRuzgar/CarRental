using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager=new CarManager(new EfCarDal());

            Console.WriteLine("--------HEPSINI LISTELE-------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model " +car.CarName+ " marka "+car.Description + " aracı günlük " 
                    + car.DailyPrice+ " TL fiyat karşılığında kiralayabilirsiniz. ");
            }
            Console.WriteLine("--------MODEL ID'SINE GÖRE-------");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.BrandId+ " Model no'lu "+car.CarName+ " marka araç listelendi.");
            }
            Console.WriteLine("--------RENK ID'SINE GÖRE-------");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.ColorId + " renk numaralı " + car.CarName + " marka araç listenlemiştir.");
            }
        }
    }
}
