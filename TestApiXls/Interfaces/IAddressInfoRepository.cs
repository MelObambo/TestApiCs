using TestApiXls.Models;

namespace TestApiXls.Interfaces
{
    public interface IAddressInfoRepository
    {
        ICollection<AddressInfo> GetAddressInfo(string addressName);
    }
}
