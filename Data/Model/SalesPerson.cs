using System.Collections.Generic;

namespace PentiaExcercise.Model
{
    public class SalesPerson
    {
        public int SalesPersonId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public List<CarPurchase> Sales { get; set; }
    }
}