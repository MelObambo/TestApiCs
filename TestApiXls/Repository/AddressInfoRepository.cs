using MySql.Data.MySqlClient;
using TestApiXls.Data;
using TestApiXls.Interfaces;
using TestApiXls.Models;

namespace TestApiXls.Repository
{
    public class AddressInfoRepository : IAddressInfoRepository
    {
        public ICollection<AddressInfo> GetAllAddressInfos()
        {
            ICollection<AddressInfo> addressInfos = [];
            DataContext dataContext = new();
            MySqlConnection connection = dataContext.getConnection();

            string req = "SELECT * FROM Address a, AddressInfo ai WHERE a.name = ai.addressName";

            MySqlCommand cmd = new(req, connection);
            connection.Open();
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                AddressInfo addressInfo = new()
                {
                    contact = (string)reader["contact"],
                    Address = new()
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
                    intercomId = reader["intercomId"] != DBNull.Value ? (string)reader["intercomId"] : "",
                    vInfo1 = reader["vInfo1"] != DBNull.Value ? (string)reader["vInfo1"] : "",
                    vInfo2 = reader["vInfo2"] != DBNull.Value ? (string)reader["vInfo2"] : ""
                };
                addressInfos.Add(addressInfo);
            }
            return addressInfos;
        }

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
                while(reader.Read())
                {
                    AddressInfo addressInfo = new()
                    {
                        contact = (string)reader["contact"],
                        Address = new()
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
                        intercomId = reader["intercomid"] != DBNull.Value ? (string)reader["intercomId"] : "",
                        vInfo1 = reader["vInfo1"] != DBNull.Value ? (string)reader["vInfo1"] : "",
                        vInfo2 = reader["vInfo2"] != DBNull.Value ? (string)reader["vInfo2"] : ""
                    };
                addressInfos.Add(addressInfo);
                }
            }
            return addressInfos;
        }

        public bool CreateAddressInfo()
        {
            throw new NotImplementedException();
        }
    }
}
