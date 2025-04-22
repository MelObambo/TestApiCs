using MySql.Data.MySqlClient;
using TestApiXls.Data;
using TestApiXls.Interfaces;
using TestApiXls.Models;

namespace TestApiXls.Repository
{
    public class AddressInfoRepository : IAddressInfoRepository
    {
        public ICollection<AddressInfo> GetAddressInfo(string addressName)
        {
            ICollection<AddressInfo> addressInfos = [];
            DataContext dataContext = new();
            MySqlConnection connection = dataContext.getConnection();

            string req = "SELECT * FROM Address a, AddressInfo ai WHERE a.name = ai.addressName && addressName = @addressName";

            MySqlCommand cmd = new(req, connection);
            cmd.Parameters.AddWithValue("@addressName", addressName);
            connection.Open();
            cmd.ExecuteNonQuery();

            using(MySqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                AddressInfo addressInfo = new AddressInfo
                {
                    Contact = (string)reader["contact"],
                    address = new Address
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
                    },
                    digicode1 = reader["digicode1"] != DBNull.Value ? (string)reader["digicode1"] : "",
                    digicode2 = reader["digicode2"] != DBNull.Value ? (string)reader["digicode2"] : "",
                    intercomid = reader["intercomid"] != DBNull.Value ? (string)reader["intercomid"] : "",
                    vinfo1 = reader["vinfo1"] != DBNull.Value ? (string)reader["vinfo1"] : "",
                    vinfo2 = reader["vinfo2"] != DBNull.Value ? (string)reader["vinfo2"] : ""
                };
                addressInfos.Add(addressInfo);
            }
            return addressInfos;
        }

        
    }
}
