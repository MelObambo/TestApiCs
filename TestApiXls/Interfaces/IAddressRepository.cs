using TestApiXls.Models;

namespace TestApiXls.Interfaces
{
    public interface IAddressRepository
    {
        ICollection<Address> GetAllAddresses();
        ICollection<Address> GetAddress(string name);
    }
}
