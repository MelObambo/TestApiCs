using TestApiXls.Data;

namespace TestApiXls.Repository
{
    public class ParcelInfoRepository
    {
        private readonly DataContext _context;

        public ICollection<Models.ParcelInfo> GetParcelInfos()
        {
            return _context.parcelInfos.OrderBy(a => a.barcodeId).ToList();
        }
        public ParcelInfoRepository(DataContext context)
        {
            _context = context;
        }
    }
}
