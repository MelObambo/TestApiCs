namespace TestApiXls.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Models.Customer> GetCustomers();
    }
}
