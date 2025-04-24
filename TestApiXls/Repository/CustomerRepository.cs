using TestApiXls.Data;
using TestApiXls.Interfaces;
using TestApiXls.Models;
using MySql.Data.MySqlClient;

namespace TestApiXls.Repository
{
    public class CustomerRepository: ICustomerRepository
    {
        private int number;

        public ICollection<Customer> GetAllCustomers() 
        {
            ICollection<Customer> customers = [];
            DataContext context = new ();
            MySqlConnection connection = context.getConnection();

            string req = "SELECT * FROM Customer;";
            MySqlCommand cmd = new(req, connection);
            connection.Open();
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Customer customer = new()
                    {
                        countryCode = (int)reader["countryCode"],
                        centerNumber = (int)reader["centerNumber"],
                        number = (int)reader["number"]
                    };

                    customers.Add(customer);
                }
                return customers;
            }
        }

        public ICollection<Customer> GetCustomer(int number)
        {
            ICollection<Customer> customers = [];
            DataContext context = new ();
            MySqlConnection connection = context.getConnection();

            string req = "SELECT * FROM Customer WHERE number = @number;";
            MySqlCommand cmd = new(req, connection);
            cmd.Parameters.AddWithValue("@number", number);
            connection.Open();
            cmd.ExecuteNonQuery();


            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Customer customer = new()
                    {
                        countryCode = (int)reader["countryCode"],
                        centerNumber = (int)reader["centerNumber"],
                        number = (int)reader["number"]
                    };

                    customers.Add(customer);
                }
                return customers;
            }
        }

        public ICollection<Customer> GetCustomer(int countryCode, int centerNumber)
        {
            ICollection<Customer> customers = [];
            DataContext context = new ();
            MySqlConnection connection = context.getConnection();

            string req = "SELECT * FROM Customer WHERE countryCode = @countryCode && centerNumber = @centerNumber;";
            MySqlCommand cmd = new(req, connection);
            cmd.Parameters.AddWithValue("@countryCode", countryCode);
            cmd.Parameters.AddWithValue("@centerNumber", centerNumber);
            connection.Open();
            cmd.ExecuteNonQuery();


            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                Customer customer = new()
                {
                    countryCode = (int)reader["countryCode"],
                    centerNumber = (int)reader["centerNumber"],
                    number = (int)reader["number"]
                };

                customers.Add(customer);
                return customers;
            }
        }

        public bool CreateCustomer(int countryCode, int centerNumber)
        {
            DataContext context = new ();
            MySqlConnection connection = context.getConnection();

            string numberReq = "SELECT number FROM Customer ORDER BY number DESC LIMIT 1;";
            int number;

            MySqlCommand numberCmd = new(numberReq, connection);
            connection.Open();
            numberCmd.ExecuteNonQuery();

            using (MySqlDataReader reader = numberCmd.ExecuteReader())
            {
                reader.Read();
                number = (int)reader["number"];
            }

            string req = "INSERT INTO Customer(countryCode, centerNumber, number) VALUES (@countryCode, @centerNumber, @number);";
            
            MySqlCommand cmd = new(req, connection);
            cmd.Parameters.AddWithValue("@countryCode", countryCode);
            cmd.Parameters.AddWithValue("@centerNumber", centerNumber);
            cmd.Parameters.AddWithValue("@number", number + 1);
            try
            {
                cmd.ExecuteNonQuery();
                this.number = number;
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public int getNumber()
        {
            return number;
        }
    }
}
