namespace TestApiXls.Models
{
    public class MultiShipmentBc
    {
        public required Shipment masterShipment { get; set; }
        public required ICollection<ShipmentBc> shipments { get; set; }
    }
}
