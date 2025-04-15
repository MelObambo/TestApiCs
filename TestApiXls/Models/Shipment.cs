namespace TestApiXls.Models
{
    public class Shipment
    {
        public required int countrycode { get; set; }
        public required int centernumber { get; set; }
        public required long parcelnumber { get; set; }
        public required long barcode { get; set; }
        public required Type type { get; set; }
        public MultiShipment MultiShipments { get; set; }
    }
}
