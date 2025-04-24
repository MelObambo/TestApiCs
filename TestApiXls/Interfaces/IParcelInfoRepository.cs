using TestApiXls.Models;

namespace TestApiXls.Interfaces
{
    public interface IParcelInfoRepository
    {
        ICollection<ParcelInfo> GetAllParcelInfos();
        ICollection<ParcelInfo> GetParcelInfo(int parcelNumber);
    }
}
