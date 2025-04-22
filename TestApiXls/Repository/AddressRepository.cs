using TestApiXls.Data;
using TestApiXls.Interfaces;
using TestApiXls.Models;
using MySql.Data.MySqlClient;

namespace TestApiXls.Repository
{
    public class AddressRepository: IAddressRepository
    {
        public ICollection<Address> GetAllAddresses()
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

        public ICollection<Address> GetAddress(string name)
        {
            ICollection<Address> addresses = [];
            DataContext dataContext = new();
            MySqlConnection connection = dataContext.getConnection();

            String req = "SELECT * FROM Address WHERE name = @name;";
            MySqlCommand cmd = new(req, connection);
            cmd.Parameters.AddWithValue("@name", name);
            connection.Open();
            cmd.ExecuteNonQuery();


            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Address address = new Address
                    {
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
                    addresses.Add(address);
                }
                return addresses;
            }
        }
    }
}
