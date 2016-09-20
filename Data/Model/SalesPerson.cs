using System.Collections.Generic;

namespace PentiaExcercise.Model
{
    /// <summary>
    /// SalesPerson class representing a sales person table in the database
    /// </summary>
    public class SalesPerson
    {
        public int SalesPersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public List<CarPurchase> Sales { get; set; }
    }
}