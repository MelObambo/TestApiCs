
using TestApiXls.Models;

namespace TestApiXls.Interfaces
{
    public interface IAddressRepository
    {
        ICollection<Address> GetAddresses();
    }
}
