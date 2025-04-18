using TestApiXls.Data;
using MySql.Data.MySqlClient;
using TestApiXls.Models;
using TestApiXls.Interfaces;

namespace TestApiXls.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;

        public ICollection<Address> GetAddresses()
        {
            DataContext dataContext = new DataContext();
            MySqlConnection connection = dataContext.getConnection();

            String req = "SELECT * FROM Address;";
            MySqlCommand cmd = new(req, connection);
            connection.Open();
            cmd.ExecuteNonQuery();

            ICollection<Address> values = [];

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Address address = new Address
                    {
                        id = (int)reader["id"],
                        name = (string)reader["name"],
                        countryPrefix = (string)reader["countryPrefix"],
                        zipCode = (string)reader["zipCode"],
                        city = (string)reader["city"],
                        street = (string)reader["street"],
                        phoneNumber = reader["phoneNumber"] != DBNull.Value ? (string)reader["phoneNumber"] : "",
                        faxNumber = reader["faxNumber"] != DBNull.Value ? (string)reader["faxNumber"] : "",
                        geoX = reader["geoX"] != DBNull.Value ? Convert.ToSingle(reader["geoX"]) : 0.0f,
                        geoY = reader["geoY"] != DBNull.Value ? Convert.ToSingle(reader["geoY"]) : 0.0f
                    };

                    values.Add(address);
                }
                return values;
            }
        }

            public ICollection<Address> GetAddresses(string name)
        {
            DataContext dataContext = new DataContext();
            MySqlConnection connection = dataContext.getConnection();

            String req = "SELECT * FROM Address WHERE name = @name;";
            MySqlCommand cmd = new(req, connection);
            cmd.Parameters.AddWithValue("@name", name);
            connection.Open();
            cmd.ExecuteNonQuery();

            ICollection<Address> values = [];

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Address address = new Address
                    {
                        id = (int)reader["id"],
                        name = (string)reader["name"],
                        countryPrefix = (string)reader["countryPrefix"],
                        zipCode = (string)reader["zipCode"],
                        city = (string)reader["city"],
                        street = (string)reader["street"],
                        phoneNumber = reader["phoneNumber"] != DBNull.Value ? (string)reader["phoneNumber"] : "",
                        faxNumber = reader["faxNumber"] != DBNull.Value ? (string)reader["faxNumber"] : "",
                        geoX = reader["geoX"] != DBNull.Value ? Convert.ToSingle(reader["geoX"]) : 0.0f,
                        geoY = reader["geoY"] != DBNull.Value ? Convert.ToSingle(reader["geoY"]) : 0.0f
                    };

                    values.Add(address);
                }
                return values;
            }
        }

        public AddressRepository(DataContext context)
        {
            this._context = context;
        }
    }
}
