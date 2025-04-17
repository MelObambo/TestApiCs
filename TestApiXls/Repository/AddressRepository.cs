using TestApiXls.Data;

namespace TestApiXls.Repository
{
    public class AddressRepository
    {
        private readonly DataContext _context;

        public ICollection<Models.Address> GetAddresses ()
        {
            return _context.addresses.OrderBy(a => a.id).ToList();
        }
        public AddressRepository(DataContext context)
        {
            _context = context;
        }
    }
}
