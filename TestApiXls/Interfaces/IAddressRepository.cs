namespace TestApiXls.Interfaces
{
    public interface IAddressRepository
    {
        ICollection<Models.Address> GetAddresses();
    }
}
