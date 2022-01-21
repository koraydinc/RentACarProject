using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ToList();

            //CarAddTest();

            //ColorAddTest();

            //BrandAddTest();

        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Entities.Concrete.Brand { BrandName = "Opel" });
            Console.WriteLine("Kayıt başarılı!");
        }

        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Entities.Concrete.Color { ColorName = "Sarı" });
            Console.WriteLine("Kayıt başarılı!");
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Entities.Concrete.Car { BrandId = 2, CarName = "1.16i", ColorId = 1, DailyPrice = 2800, ModelYear = 2021, Description = "Tüm muayneleri yapılmıştır." });
            Console.WriteLine("Kayıt başarılı!");
        }

        private static void ToList()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", car.CarId, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }
    }
}