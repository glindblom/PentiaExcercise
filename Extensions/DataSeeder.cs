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
            
            if (!db.Addresses.Any())
            {
                db.Addresses.AddRange(new Address[]{
                    new Address() { StreetName = "Test Street", StreetNumber = 33 },
                    new Address() { StreetName = "Test Avenue", StreetNumber = 88 },
                    new Address() { StreetName = "Test Road", StreetNumber = 5 },
                    new Address() { StreetName = "Test Avenue", StreetNumber = 21 },
                    new Address() { StreetName = "Odd Lane", StreetNumber = 1 }
                });
            }
            
            if (!db.Customers.Any())
            {
                db.Customers.AddRange(new Customer[]{
                    new Customer() {
                        FirstName = "Tom",
                        LastName = "Selleck",
                        Age = 71,
                        Created = DateTime.Now,
                        AddressId = 1
                    },
                    new Customer() {
                        FirstName = "Robert",
                        LastName = "Downey",
                        Age = 51,
                        Created = DateTime.Now,
                        AddressId = 2
                    },
                    new Customer() {
                        FirstName = "Robert",
                        LastName = "Duvall",
                        Age = 85,
                        Created = DateTime.Now,
                        AddressId = 3
                    },
                    new Customer() {
                        FirstName = "Clint",
                        LastName = "Eastwood",
                        Age = 86,
                        Created = DateTime.Now,
                        AddressId = 4
                    },
                    new Customer() {
                        FirstName = "James",
                        LastName = "Newell Osterberg",
                        Age = 69,
                        Created = DateTime.Now,
                        AddressId = 5
                    }
                });
            }

            if (!db.SalesPersons.Any())
            {

            }

            if (!db.Cars.Any())
            {

            }

            if (!db.CarPurchases.Any())
            {

            }

            db.SaveChanges();
        }
    }
}