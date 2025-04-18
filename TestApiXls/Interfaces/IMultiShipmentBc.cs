namespace TestApiXls.Interfaces
{
    public interface IMultiShipmentBc
    {
        ICollection<Models.MultiShipmentBc> GetMultiShipmentBc();
        ICollection<Models.MultiShipmentBc> CreateMultiShipmentBc();
        ICollection<Models.MultiShipmentBc> UpdateMultiShipmentBcs();
    }
}
