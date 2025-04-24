using TestApiXls.Models;

namespace TestApiXls.Interfaces
{
    public interface IAddressInfoRepository
    {
        ICollection<AddressInfo> GetAllAddressInfos();
        ICollection<AddressInfo> GetAddressInfo(string addressName);

        bool CreateAddressInfo();
    }
}
