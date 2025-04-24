namespace TestApiXls.Models
{
    public class ShipmentBc
    {
        public required BcDataExt Shipment { get; set; }
        public required Type Type { get; set; }
        public MultiShipmentBc? MultiShipmentBc { get; set; }
        
    }
}
