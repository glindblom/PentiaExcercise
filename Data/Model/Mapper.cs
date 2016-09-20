using PentiaExcercise.ViewModels;
using System.Linq;
using System;

namespace PentiaExcercise.Model
{
    /// <summary>
    /// Static helper class used for mapping from models to viewmodels.
    /// Would preferably replace this with AutoMapper to ease extensability
    /// but due to the size of the task, this will do.
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Maps the data of a Car object to a CarViewModel
        /// </summary>
        /// <param name="car">The Car object to map from</param>
        /// <returns>A CarViewModel representation of the data</returns>
        public static CarViewModel CarToModel(Car car)
        {
            return new CarViewModel()
            {
                CarId = car.CarId,
                Make = car.Make,
                Model = car.Model,
                Color = car.Color,
                Extras = car.Extras,
                RecommendedPrice = car.RecommendedPrice
            };
        }

        /// <summary>
        /// Maps the data of a CarPurchase object to a CarPurchaseViewModel
        /// </summary>
        /// <param name="carPurchase">The CarPurchase object to map from</param>
        /// <returns>A CarPurchaseViewModel representation of the data</returns>
        public static CarPurchaseViewModel CarPurchaseToModel(CarPurchase carPurchase)
        {
            var result = new CarPurchaseViewModel()
            {
                CarPurchaseId = carPurchase.CarPurchaseId,
                OrderDate = carPurchase.OrderDate,
                PricePaid = carPurchase.PricePaid,
                SalesPerson = SalesPersonToModel(carPurchase.SalesPerson),
                Customer = CustomerToModel(carPurchase.Customer),
                Car = CarToModel(carPurchase.Car)
            };

            // Calculate the percentage difference between the price paid for the car
            // and the recommended price.
            result.PriceDifference = Math.Round(((result.PricePaid - result.Car.RecommendedPrice) / result.Car.RecommendedPrice) * 100, 2);

            return result;
        }
        
        /// <summary>
        /// Maps the data of a Customer object to a CustomerViewModel
        /// </summary>
        /// <param name="customer">Tne Customer object to map from</param>
        /// <returns>A CustomerViewModel representation of the data</returns>
        public static CustomerViewModel CustomerToModel(Customer customer)
        {
            var result = new CustomerViewModel()
            {
                CustomerId = customer.CustomerId,
                Name = string.Format($"{customer.FirstName} {customer.LastName}"),
                Age = customer.Age,
                Created = customer.Created,
                Address = customer.Address
            };

            result.Purchases = (from purchase in customer.Purchases
                                select new CarPurchaseViewModel() {
                                    CarPurchaseId = purchase.CarPurchaseId,
                                    OrderDate = purchase.OrderDate,
                                    PricePaid = purchase.PricePaid,
                                    SalesPerson = SalesPersonToModel(purchase.SalesPerson),
                                    Customer = result,
                                    Car = CarToModel(purchase.Car)
                                }).ToList();

            return result;
        }

        /// <summary>
        /// Maps the data of a SalesPerson object to a SalesPersonViewModel
        /// </summary>
        /// <param name="salesPerson">The SalesPerson object to map from</param>
        /// <returns>A SalesPersonViewModel representation of the data</returns>
        public static SalesPersonViewModel SalesPersonToModel(SalesPerson salesPerson)
        {
            var result = new SalesPersonViewModel()
            {
                SalesPersonId = salesPerson.SalesPersonId,
                Name = $"{salesPerson.FirstName} {salesPerson.LastName}",
                Salary = salesPerson.Salary,
                Address = salesPerson.Address
            };

            result.Sales = (from sale in salesPerson.Sales
                            select new CarPurchaseViewModel() {
                                    CarPurchaseId = sale.CarPurchaseId,
                                    OrderDate = sale.OrderDate,
                                    PricePaid = sale.PricePaid,
                                    SalesPerson = result,
                                    Customer = CustomerToModelLight(sale.Customer),
                                    Car = CarToModel(sale.Car)
                            }).ToList();

            return result;
        }

        /// <summary>
        /// Maps the data of a Customer object to a CustomerViewModel
        /// Ugly method that is required due to the SalesPersonToModel-method
        /// causing StackOverflowExceptions otherwise. Can't figure out why,
        /// though.
        /// </summary>
        /// <param name="customer">Tne Customer object to map from</param>
        /// <returns>A CustomerViewModel representation of the data</returns>
        public static CustomerViewModel CustomerToModelLight(Customer customer)
        {
            if (customer == null) return null;
            var result = new CustomerViewModel()
            {
                CustomerId = customer.CustomerId,
                Name = string.Format($"{customer.FirstName} {customer.LastName}"),
                Age = customer.Age,
                Created = customer.Created,
                Address = customer.Address
            };

            return result;
        }
    }
}