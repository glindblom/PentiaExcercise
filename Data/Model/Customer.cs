using System;

namespace PentiaExcercise.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}