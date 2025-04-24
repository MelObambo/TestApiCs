namespace TestApiXls.Models
{
    public class MultiShipment
    {
        public required Shipment MasterShipment { get; set; }
        public required ICollection<Shipment> Shipments { get; set; }
    }
}
