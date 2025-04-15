namespace TestApiXls.Models
{
    public class MultiShipment
    {
        public required Shipment masterShipment { get; set; }
        public required ICollection<Shipment> Shipments { get; set; }
    }
}
