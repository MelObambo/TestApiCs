using MySql.Data.MySqlClient;
using TestApiXls.Data;
using TestApiXls.Interfaces;
using TestApiXls.Models;

namespace TestApiXls.Repository
{
    public class ParcelInfoRepository : IParcelInfoRepository
    {
        public ICollection<ParcelInfo> GetAllParcelInfos()
        {
            ICollection<ParcelInfo> parcelInfos = [];
            DataContext context = new();
            MySqlConnection connection = context.getConnection();

            string req = "SELECT * FROM Parcel p, ParcelInfo pi WHERE p.parcelNumber = pi.parcelNumber";
            MySqlCommand cmd = new(req, connection);
            connection.Open();
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ParcelInfo parcelInfo = new()
                    {
                        Parcel = new Parcel
                        {
                            countryCode = (int)reader["countryCode"],
                            centerNumber = (int)reader["centerNumber"],
                            parcelNumber = (int)reader["parcelNumber"]
                        },
                        BarCodeSource = (string)reader["barCodeSource"],
                        BarcodeId = (int)reader["barCodeId"]
                    };
                    parcelInfos.Add(parcelInfo);
                }
                return parcelInfos;
            }
        }

        public ICollection<ParcelInfo> GetParcelInfo(int parcelNumber)
        {
            ICollection<ParcelInfo> parcelInfos = [];
            DataContext context = new();
            MySqlConnection connection = context.getConnection();

            string req = "SELECT * FROM Parcel p, ParcelInfo pi WHERE p.parcelNumber = pi.parcelNumber && pi.parcelNumber = @parcelNumber";
            MySqlCommand cmd = new(req, connection);
            cmd.Parameters.AddWithValue("@parcelNumber", parcelNumber);
            connection.Open();
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ParcelInfo parcelInfo = new()
                    {
                        Parcel = new()
                        {
                            countryCode = (int)reader["countryCode"],
                            centerNumber = (int)reader["centerNumber"],
                            parcelNumber = (int)reader["parcelNumber"]
                        },
                        BarCodeSource = (string)reader["barCodeSource"],
                        BarcodeId = (int)reader["barCodeId"]
                    };
                    parcelInfos.Add(parcelInfo);
                }
                return parcelInfos;
            }
        }
    }
}
