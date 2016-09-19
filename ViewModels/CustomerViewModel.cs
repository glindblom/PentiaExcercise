using System;
using System.Collections.Generic;

namespace PentiaExcercise.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }
    
        public int AddressId { get; set; }

        public List<CarPurchaseViewModel> Purchases { get; set; }
    }
}