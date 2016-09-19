using System;

namespace PentiaExcercise.ViewModels
{
    public class CarPurchaseViewModel
    {
        public int CarPurchaseId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal PricePaid { get; set; }
        public decimal PriceDifference { get; set; }

        public SalesPersonViewModel SalesPerson { get; set; }
        public CustomerViewModel Customer { get; set; }
        public CarViewModel Car { get; set; }
    }
}