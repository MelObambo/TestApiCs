using TestApiXls.Data;

namespace TestApiXls.Repository
{
    public class ShipmentBcRepository
    {
        private readonly DataContext _context;

        public ICollection<Models.ShipmentBc> GetShipmentBc()
        {
            return _context.shipmentBcs.OrderBy(a => a.Shipment).Join(_context.bcDataExts.OrderBy(b => b.barCodeId), _context.bcDataExts).ToList();
        }

    }
}
