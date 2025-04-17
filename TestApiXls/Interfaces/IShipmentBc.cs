using TestApiXls.Models;

namespace TestApiXls.Interfaces
{
    public interface IShipmentBc
    {
        ICollection<ShipmentBc> GetShipmentBc();
        ICollection<ShipmentBc> CreateShipmentBc();
        ICollection<ShipmentBc> UpdateShipmentBc();
    }
}
