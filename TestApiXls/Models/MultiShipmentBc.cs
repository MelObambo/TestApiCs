namespace TestApiXls.Models
{
    public class MultiShipmentBc
    {
        public required Shipment MasterShipment { get; set; }
        public required ICollection<ShipmentBc> Shipments { get; set; }
    }
}
