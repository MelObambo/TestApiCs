namespace TestApiXls.Interfaces
{
    public interface IAddressRepository
    {
        ICollection<Models.Address> GetAddresses();
        ICollection<Models.Address> GetAddresses(string name);
    }
}
