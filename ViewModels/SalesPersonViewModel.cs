using System.Collections.Generic;

namespace PentiaExcercise.ViewModels
{
    public class SalesPersonViewModel
    {
        public int SalesPersonId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }

        public List<CarPurchaseViewModel> Sales { get; set; }
    }
}