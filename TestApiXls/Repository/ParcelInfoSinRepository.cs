using MySql.Data.MySqlClient;
using TestApiXls.Data;
using TestApiXls.Interfaces;
using TestApiXls.Models;

namespace TestApiXls.Repository
{
    public class ParcelInfoSinRepository : IParcelInfoSinRepository
    {

        public ICollection<ParcelInfoSin> GetAllParcelInfoSins()
        {
            ICollection<ParcelInfoSin> parcelInfoSins = [];
            DataContext context = new();
            MySqlConnection connection = context.getConnection();

            string req = "SELECT * FROM Parcel p, ParcelInfo pi, ParcelInfoSin pis WHERE p.parcelNumber = pi.parcelNumber && p.parcelNumber = pis.parcelNumber";
            MySqlCommand cmd = new(req, connection);
            connection.Open();
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ParcelInfoSin parcelInfoSin = new()
                    {
                        ParcelInfo = new()
                        {
                            Parcel = new()
                            {
                                countryCode = (int)reader["countryCode"],
                                centerNumber = (int)reader["centerNumber"],
                                parcelNumber = (int)reader["parcelNumber"]
                            },
                            BarCodeSource = (string)reader["barCodeSource"],
                            BarcodeId = (int)reader["barCodeSource"]
                        },
                        sin = (string)reader["sin"]
                    };
                        parcelInfoSins.Add(parcelInfoSin);
                }
                return parcelInfoSins;
            }
        }

        public ICollection<ParcelInfoSin> GetParcelInfoSin(int parcelNumber)
        {
            ICollection<ParcelInfoSin> parcelInfoSins = [];
            DataContext context = new();
            MySqlConnection connection = context.getConnection();

            string req = "SELECT * FROM Parcel p, ParcelInfo pi, ParcelInfoSin pis WHERE p.parcelNumber = pi.parcelNumber && p.parcelNumber = pis.parcelNumber && p.parcelNumber = @parcelNumber;";
            MySqlCommand cmd = new(req, connection);
            cmd.Parameters.AddWithValue("@parcelNumber", parcelNumber);
            connection.Open();
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ParcelInfoSin parcelInfoSin = new()
                    {
                        ParcelInfo = new()
                        {
                            Parcel = new(                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       )
                            {
                                countryCode = (int)reader["countryCode"],
                                centerNumber = (int)reader["centerNumber"],
                                parcelNumber = (int)reader["parcelNumber"]
                            },
                            BarCodeSource = (string)reader["barCodeSource"],
                            BarcodeId = (int)reader["barCodeSource"]
                        },
                        sin = (string)reader["sin"]
                    };
                    parcelInfoSins.Add(parcelInfoSin);
                }
                return parcelInfoSins;
            }
        }
        public bool CreateParcelInfoSin()
        {
            throw new NotImplementedException();
        }
    }
}
