using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using PentiaExcercise.Context;
using PentiaExcercise.Model;

namespace PentiaExcercise.Extensions
{
    public static class DataSeeder
    {
        
        public static void SeedData(this IApplicationBuilder application)
        {
            var db = (SiteContext)application.ApplicationServices.GetService(typeof(SiteContext));
            
            if (!db.Customers.Any())
            {
                db.Customers.AddRange(new Customer[]{
                    new Customer() {
                        FirstName = "Tom",
                        LastName = "Selleck",
                        Age = 71,
                        Created = DateTime.Now,
                        Address = "Test Avenue 23"
                    },
                    new Customer() {
                        FirstName = "Robert",
                        LastName = "Downey",
                        Age = 51,
                        Created = DateTime.Now,
                        Address = "Test Avenue 23"
                    },
                    new Customer() {
                        FirstName = "Robert",
                        LastName = "Duvall",
                        Age = 85,
                        Created = DateTime.Now,
                        Address = "Test Avenue 23"
                    },
                    new Customer() {
                        FirstName = "Clint",
                        LastName = "Eastwood",
                        Age = 86,
                        Created = DateTime.Now,
                        Address = "Test Avenue 23"
                    },
                    new Customer() {
                        FirstName = "James",
                        LastName = "Newell Osterberg",
                        Age = 69,
                        Created = DateTime.Now,
                        Address = "Test Avenue 23"
                    }
                });
                db.SaveChanges(); 
            }

            if (!db.SalesPersons.Any())
            {
                db.SalesPersons.AddRange(new SalesPerson[] {
                    new SalesPerson() {
                        Name = "Alf Bengtsson",
                        Salary = 35000,
                        Address = "Test Avenue 23"
                    },
                    new SalesPerson() {
                        Name = "Gunnar Niequist",
                        Salary = 28000,
                        Address = "Test Avenue 23"
                    },
                    new SalesPerson() {
                        Name = "Frej Olsson",
                        Salary = 29500,
                        Address = "Test Avenue 23"
                    },
                    new SalesPerson() {
                        Name = "Olof Jonsson",
                        Salary = 40000,
                        Address = "Test Avenue 23"
                    }
                });
                db.SaveChanges();
            }

            if (!db.Cars.Any())
            {
                db.Cars.AddRange(new Car[] {
                    new Car() {
                        Make = "Volkswagen",
                        Model = "Golf Gti",
                        Color = "Green",
                        Extras = "Radio",
                        RecommendedPrice = 130000
                    },
                    new Car() {
                        Make = "Volvo",
                        Model = "V70",
                        Color = "Black",
                        Extras = "Police radio, sirens",
                        RecommendedPrice = 250000
                    },
                    new Car() {
                        Make = "Ford",
                        Model = "Fiesta",
                        Color = "Blue",
                        Extras = "22 rims",
                        RecommendedPrice = 105000
                    },
                    new Car() {
                        Make = "Opel",
                        Model = "Astra",
                        Color = "Red",
                        Extras = "Leather seats",
                        RecommendedPrice = 159900
                    },
                    new Car() {
                        Make = "Hyundai",
                        Model = "i30",
                        Color = "White",
                        Extras = "Rain sensor",
                        RecommendedPrice = 189900
                    }
                });
                db.SaveChanges();
            }

            if (!db.CarPurchases.Any())
            {
                db.CarPurchases.AddRange(new CarPurchase[] {
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 205500,
                        SalesPersonId = 1,
                        CustomerId = 1,
                        CarId = 1
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 01, 20),
                        PricePaid = 155000,
                        SalesPersonId = 2,
                        CustomerId = 2,
                        CarId = 2
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 01, 20),
                        PricePaid = 130000,
                        SalesPersonId = 3,
                        CustomerId = 3,
                        CarId = 3
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 150000,
                        SalesPersonId = 4,
                        CustomerId = 4,
                        CarId = 4
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 01, 20),
                        PricePaid = 95000,
                        SalesPersonId = 1,
                        CustomerId = 3,
                        CarId = 2
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 120000,
                        SalesPersonId = 2,
                        CustomerId = 4,
                        CarId = 1
                    }
                });
                db.SaveChanges();
            }
        }
    }
}