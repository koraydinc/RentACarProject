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

            //UserAddTest();

            //CustomerAddTest();

            //RentalAddTest();

        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Entities.Concrete.Rental { CarId = 2, CustomerId = 1, RentDate = DateTime.Now });
        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Entities.Concrete.Customer { UserId = 1, CompanyName = "Dinc A.S" });
        }

        //private static void UserAddTest()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    userManager.Add(new Entities.Concrete.User { FirstName = "Koray", LastName = "Dinc", Email = "berkay@hotmail.com" });
        //}

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

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", car.Id, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }
    }
}