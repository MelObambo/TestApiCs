using TestApiXls.Models;

namespace TestApiXls.Interfaces
{
    public interface IParcelInfoSinRepository
    {
        ICollection<ParcelInfoSin> GetAllParcelInfoSins();
        ICollection<ParcelInfoSin> GetParcelInfoSin(int parcelNumber);

        bool CreateParcelInfoSin();
        int GetNumber();
    }
}
