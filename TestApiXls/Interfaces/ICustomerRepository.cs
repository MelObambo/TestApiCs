using TestApiXls.Models;

namespace TestApiXls.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetAllCustomers();
        ICollection<Customer> GetCustomer(int number);
        ICollection<Customer> GetCustomer(int countryCode, int centerNumber);

        bool CreateCustomer(int countryCode, int centerNumber);
        int getNumber();
    }
}
