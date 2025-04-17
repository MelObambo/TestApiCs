namespace TestApiXls.Models
{
    public class Address
    {
        public required int id { get; set; }
        public required string name { get; set; }
        public required string countryPrefix { get; set; }
        public required string zipCode { get; set; }
        public required string city { get; set; }
        public required string street { get; set; }
        public string phoneNumber { get; set; }
        public string faxNumber { get; set; }
        public string geoX { get; set; }
        public string geoY { get; set; }
    }
}
