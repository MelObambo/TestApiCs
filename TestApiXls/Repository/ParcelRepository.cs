using MySql.Data.MySqlClient;
using TestApiXls.Data;
using TestApiXls.Interfaces;
using TestApiXls.Models;

namespace TestApiXls.Repository
{
    public class ParcelRepository : IParcelRepository
    {
        public ICollection<Parcel> GetAllParcels()
        {
            ICollection<Parcel> parcels = [];
            DataContext context = new();
            MySqlConnection connection = context.getConnection();

            string req = "SELECT * FROM Parcel";
            MySqlCommand cmd = new(req, connection);
            connection.Open();
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Parcel parcel = new Parcel
                    {
                        countryCode = (int)reader["countryCode"],
                        centerNumber = (int)reader["centerNumber"],
                        parcelNumber = (int)reader["parcelNumber"]
                    };
                    parcels.Add(parcel);
                }
                return parcels;
            }
        }

        public ICollection<Parcel> GetParcel(int parcelNumber)
        {
            ICollection<Parcel> parcels = [];
            DataContext context = new();
            MySqlConnection connection = context.getConnection();

            string req = "SELECT * FROM Parcel WHERE parcelNumber = @parcelNumber";
            MySqlCommand cmd = new(req, connection);
            cmd.Parameters.AddWithValue("@parcelNumber", parcelNumber);
            connection.Open();
            cmd.ExecuteNonQuery();

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Parcel parcel = new Parcel
                    {
                        countryCode = (int)reader["countryCode"],
                        centerNumber = (int)reader["centerNumber"],
                        parcelNumber = (int)reader["parcelNumber"]
                    };
                    parcels.Add(parcel);
                }
                return parcels;
            }
        }
    }
}
