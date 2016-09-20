using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using PentiaExcercise.Context;
using PentiaExcercise.Model;

namespace PentiaExcercise.Extensions
{
    public static class DataSeeder
    {
        /// <summary>
        /// Helper extension method to seed an empty database with test data.
        /// </summary>
        /// <param name="application">The IApplicationBuilder instance where the DbContext resides</param>
        public static void SeedData(this IApplicationBuilder application)
        {
            // Fetch the DbContext as a service from the ApplicationBuilder
            var db = (SiteContext)application.ApplicationServices.GetService(typeof(SiteContext));
            
            // What follows are some quick and dirty data generation
            // Will only execute if the tables are empty
            if (!db.Customers.Any())
            {
                db.Customers.AddRange(new Customer[]{
                    new Customer() {
                        FirstName = "Melinda",
                        LastName = "Patton",
                        Age = 35,
                        Address = "P.O. Box 374, 6574 Ac Street",
                        Created = DateTime.Now
                    },
                    new Customer() {
                        FirstName = "Bryar",
                        LastName = "Jacobs",
                        Age = 25,
                        Address = "Ap #586-4204 Magnis Street",
                        Created = new DateTime(2015, 07, 03)
                    },
                    new Customer() {
                        FirstName = "Nina",
                        LastName = "Hardy",
                        Age = 45,
                        Address = "683-130 Vitae Street",
                        Created = new DateTime(2015, 04, 04)
                    },
                    new Customer() {
                        FirstName = "Byron",
                        LastName = "Hobbs",
                        Age = 33,
                        Address = "962-5401 Vestibulum Avenue",
                        Created = new DateTime(2017, 01, 26)
                    },
                    new Customer() {
                        FirstName = "Darius",
                        LastName = "Cobb",
                        Age = 67,
                        Address = "Ap #326-3769 Libero Avenue",
                        Created = new DateTime(2015, 05, 20)
                    },
                    new Customer() {
                        FirstName = "Byron",
                        LastName = "Hobbs",
                        Age = 33,
                        Address = "962-5401 Vestibulum Avenue",
                        Created = new DateTime(2017, 01, 26)
                    },
                    new Customer() {
                        FirstName = "Chandler",
                        LastName = "Hayes",
                        Age = 54,
                        Address = "962-2601 Vestibulum Avenue",
                        Created = new DateTime(2017, 03, 16)
                    },
                    new Customer() {
                        FirstName = "Steven",
                        LastName = "Hahn",
                        Age = 55,
                        Address = "5001 Aliquet Street",
                        Created = new DateTime(2014, 10, 25)
                    }
                });
                db.SaveChanges(); 
            }

            if (!db.SalesPersons.Any())
            {
                db.SalesPersons.AddRange(new SalesPerson[] {
                    new SalesPerson() {
                        FirstName = "Garrett",
                        LastName = "Patrick",
                        Salary = 30000,
                        Address = "Test Street 54"
                    },
                    new SalesPerson() {
                        FirstName = "Nathaniel",
                        LastName = "Webster",
                        Salary = 32000,
                        Address = "Test Street 33"
                    },
                    new SalesPerson() {
                        FirstName = "Casey",
                        LastName = "Spencer",
                        Salary = 27500,
                        Address = "4489 Quis Street"
                    },
                    new SalesPerson() {
                        FirstName = "Brendan",
                        LastName = "Owens",
                        Salary = 28200,
                        Address = "8595 Libero Avenue"
                    }
                });
                db.SaveChanges();
            }

            if (!db.Cars.Any())
            {
                db.Cars.AddRange(new Car[] {
                    new Car() {
                        Make = "Volvo",
                        Model = "XC60",
                        Color = "Red",
                        Extras = "GPS",
                        RecommendedPrice = 299900
                    },
                    new Car() {
                        Make = "Volvo",
                        Model = "XC60",
                        Color = "Blue",
                        Extras = "",
                        RecommendedPrice = 285000
                    },
                    new Car() {
                        Make = "Opel",
                        Model = "Astra",
                        Color = "Blue",
                        Extras = "GPS",
                        RecommendedPrice = 159900
                    },
                    new Car() {
                        Make = "Opel",
                        Model = "Astra",
                        Color = "Red",
                        Extras = "",
                        RecommendedPrice = 159000
                    },
                    new Car() {
                        Make = "Volvo",
                        Model = "V70",
                        Color = "Black",
                        Extras = "GPS",
                        RecommendedPrice = 280000
                    },
                    new Car() {
                        Make = "Volvo",
                        Model = "V70",
                        Color = "Gold",
                        Extras = "GPS",
                        RecommendedPrice = 290000
                    },
                    new Car() {
                        Make = "Hyundai",
                        Model = "i30",
                        Color = "Blue",
                        Extras = "",
                        RecommendedPrice = 120000
                    },
                    new Car() {
                        Make = "Hyundai",
                        Model = "i30",
                        Color = "Blue",
                        Extras = "",
                        RecommendedPrice = 120000
                    },
                    new Car() {
                        Make = "Golf",
                        Model = "Gti",
                        Color = "White",
                        Extras = "GPS",
                        RecommendedPrice = 270000
                    }
                });
                db.SaveChanges();
            }

            if (!db.CarPurchases.Any())
            {
                db.CarPurchases.AddRange(new CarPurchase[] {
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 290500,
                        SalesPersonId = 1,
                        CustomerId = 1,
                        CarId = 1
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 160000,
                        SalesPersonId = 1,
                        CustomerId = 1,
                        CarId = 3
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 158000,
                        SalesPersonId = 3,
                        CustomerId = 2,
                        CarId = 4
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 160000,
                        SalesPersonId = 3,
                        CustomerId = 3,
                        CarId = 4
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 122000,
                        SalesPersonId = 3,
                        CustomerId = 4,
                        CarId = 8
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 160000,
                        SalesPersonId = 1,
                        CustomerId = 1,
                        CarId = 3
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 160000,
                        SalesPersonId = 4,
                        CustomerId = 5,
                        CarId = 7
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 160000,
                        SalesPersonId = 4,
                        CustomerId = 6,
                        CarId = 6
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 160000,
                        SalesPersonId = 4,
                        CustomerId = 7,
                        CarId = 5
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 160000,
                        SalesPersonId = 2,
                        CustomerId = 2,
                        CarId = 4
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 160000,
                        SalesPersonId = 3,
                        CustomerId = 8,
                        CarId = 2
                    },
                    new CarPurchase() {
                        OrderDate = new DateTime(2016, 05, 05),
                        PricePaid = 160000,
                        SalesPersonId = 1,
                        CustomerId = 5,
                        CarId = 3
                    }
                });
                db.SaveChanges();
            }
        }
    }
}