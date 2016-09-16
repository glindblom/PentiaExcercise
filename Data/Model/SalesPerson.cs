namespace PentiaExcercise.Model
{
    public class SalesPerson
    {
        public int SalesPersonId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}