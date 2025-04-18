using TestApiXls.Data;

namespace TestApiXls.Repository
{
    public class ShipmentBcRepository
    {
        private readonly DataContext _context;

        public IEnumerable<Models.ShipmentBc> GetShipmentBc()
        {
            return _context.shipmentBcs.OrderBy(a => a.Shipment);
        }

    }
}
