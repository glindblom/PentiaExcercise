using System;
using System.Collections.Generic;

namespace PentiaExcercise.Model
{
    /// <summary>
    /// Customer class representing a customer table in the database.
    /// </summary>
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }

        public List<CarPurchase> Purchases { get; set; }
    }
}