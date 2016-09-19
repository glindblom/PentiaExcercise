using System.ComponentModel.DataAnnotations;

namespace PentiaExcercise.ViewModels
{
    public class CarViewModel
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Extras { get; set; }
        [DataType(DataType.Currency)]
        public decimal RecommendedPrice { get; set; }
    }
}