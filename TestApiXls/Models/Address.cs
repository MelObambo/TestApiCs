namespace TestApiXls.Models
{
    public class Address
    {
        public required string name { get; set; }
        public required string countryPrefix { get; set; }
        public required string zipCode { get; set; }
        public required string city { get; set; }
        public required string street { get; set; }
        public string phoneNumber { get; set; }
        public string faxNumber { get; set; }
        public float geoX { get; set; }
        public float geoY { get; set; }

    }
}
