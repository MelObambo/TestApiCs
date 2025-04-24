using TestApiXls.Models;

namespace TestApiXls.Interfaces
{
    public interface IParcelRepository
    {
        public ICollection<Parcel> GetAllParcels();
        public ICollection<Parcel> GetParcel(int parcelNumber);
    }
}
