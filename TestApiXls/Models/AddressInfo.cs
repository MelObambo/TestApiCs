namespace TestApiXls.Models
{
    public class AddressInfo
    {
        public required string contact { get; set; }
        public required Address Address { get; set; }
        public string? digicode1 { get; set; }
        public string? digicode2 { get; set; }
        public string?  intercomId { get; set; }
        public string? vInfo1 { get; set; }
        public string? vInfo2 { get; set; }
    }
}
