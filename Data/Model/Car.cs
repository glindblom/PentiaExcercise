namespace PentiaExcercise.Model
{
    /// <summary>
    /// Car model class representing a car table in the database.
    /// Some iffy design choices, but this is just for show,
    /// otherwise I would have moved a lot of data to other tables.
    /// </summary>
    public class Car
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Extras { get; set; }
        public decimal RecommendedPrice { get; set; }
    }
}