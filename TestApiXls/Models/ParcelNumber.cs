namespace TestApiXls.Models
{
    public class ParcelNumber
    {
        public required int id { get; set; }
        public required int countryCode { get; set; }
        public required int centerNumber { get; set; }
        public required long parcelNumber { get; set; }
    }
}
