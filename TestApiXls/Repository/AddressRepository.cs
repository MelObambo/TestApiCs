using TestApiXls.Data;

namespace TestApiXls.Repository
{
    public class AddressRepository
    {
        private readonly DataContext _context;

        public AddressRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Address> GetAddresses{
        return _context.Address.OrderBy().;
}
}
