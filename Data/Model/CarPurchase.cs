using System;

namespace PentiaExcercise.Model
{
    /// <summary>
    /// CarPurchase class representing a car purchase table in the database.
    /// </summary>
    public class CarPurchase
    {
        public int CarPurchaseId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal PricePaid { get; set; }

        public int SalesPersonId { get; set; }
        public SalesPerson SalesPerson { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}