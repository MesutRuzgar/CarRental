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
            //CarManagerTest();

            //BrandManagerTest();

            //ColorManagerTest();
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("--------RENK EKLEME-------");
            colorManager.Add(new Color { ColorName = "Mavi" });
            colorManager.Add(new Color { ColorName = "Silinecek renk" });
            colorManager.Add(new Color { ColorName = "Güncellenecek renk" });
            Console.WriteLine("--------RENK SILME-------");
            colorManager.Delete(new Color { ColorId = 1003, ColorName = "Silinecek renk" });
            Console.WriteLine("--------RENK GUNCELLEME-------");
            colorManager.Update(new Color { ColorId = 1004, ColorName = "Güncellenecek renkV2" });
            Console.WriteLine("--------Bütün Renkler------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
          
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("--------MARKA EKLEME-------");
            brandManager.Add(new Brand { BrandName = "Opel" });
            brandManager.Add(new Brand { BrandName = "Silinecek marka" });
            brandManager.Add(new Brand { BrandName = "Güncellenecek marka" });
            Console.WriteLine("--------MARKA SILME-------");
            brandManager.Delete(new Brand { BrandId = 1003, BrandName = "Silinecek marka" });
            Console.WriteLine("--------MARKA GUNCELLEME-------");
            brandManager.Update(new Brand { BrandId = 1004, BrandName = "Güncellenecek markaV2" });
            Console.WriteLine("--------Bütün Markalar------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
                    }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("--------HEPSINI LISTELE-------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " Model " + car.CarName + " marka " + car.Description + " aracı günlük "
                    + car.DailyPrice + " TL fiyat karşılığında kiralayabilirsiniz. ");
            }
            Console.WriteLine("--------MODEL ID'SINE GÖRE-------");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.BrandId + " Model no'lu " + car.CarName + " marka araç listelendi.");
            }
            Console.WriteLine("--------RENK ID'SINE GÖRE-------");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.ColorId + " renk numaralı " + car.CarName + " marka araç listenlemiştir.");
            }
            Console.WriteLine("--------DTO KATMANLI KATEGORIYE GÖRE CAGIR-------");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName+ " / "+car.BrandName+ " / "+car.ColorName+ " / "+car.DailyPrice+ " TL'den başlayan fiyatlarla.");
                                               
            }

            Console.WriteLine("--------ARAC EKLEME-------");
            carManager.Add(new Car { CarName = "Astra", BrandId = 5, ColorId = 6, Description = "Sedan,Düz vites", ModelYear = "2018", DailyPrice = 175 });

            Console.WriteLine("-------ARAC SILME-------");
            carManager.Delete(new Car { Id = 1026, CarName = "Astra", BrandId = 0, ColorId = 0, Description = "Sedan,Düz vites", ModelYear = "2018", DailyPrice = 175 });
        
            Console.WriteLine("-------ARAC GUNCELLEME-------");
            carManager.Update(new Car { Id = 1005, CarName = "AstraV2.0", BrandId = 5, ColorId = 5, Description = "Sedan,Otomatik vites", ModelYear = "2018", DailyPrice = 200 });

        }
       
    }
}
