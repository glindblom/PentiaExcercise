using PentiaExcercise.ViewModels;
using System.Linq;
using System;

namespace PentiaExcercise.Model
{
    public static class Mapper
    {
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

            result.PriceDifference = Math.Round(((result.PricePaid - result.Car.RecommendedPrice) / result.Car.RecommendedPrice) * 100, 2);

            return result;
        }

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

        public static SalesPersonViewModel SalesPersonToModel(SalesPerson salesPerson)
        {
            var result = new SalesPersonViewModel()
            {
                SalesPersonId = salesPerson.SalesPersonId,
                Name = salesPerson.Name,
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
    }
}