using System.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestApiXls.Models;

using MySql.Data.MySqlClient;

namespace TestApiXls.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Address> addresses { get; set; }
        public DbSet<AddressInfo> addressInfos { get; set; }
        public DbSet<BcDataExt> bcDataExts { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Label> labels { get; set; }
        public DbSet<MultiShipment> multiShipments { get; set; }
        public DbSet<MultiShipmentBc> multiShipmentBcs { get; set; }
        public DbSet<ParcelInfo> parcelInfos { get; set; }
        public DbSet<ParcelInfoSin> parcelInfoSins { get; set; }
        public DbSet<Parcel> parcelNumber { get; set; }
        public DbSet<Shipment> shippingDatas { get; set; }
        public DbSet<ShipmentBc> shipmentBcs { get; set; }
        public DbSet<Models.Type> types { get; set; }

        public MySqlConnection getConnection()
        {
            var builder = WebApplication.CreateBuilder();
            string connectionString = "Server=localhost;Database=test_api;User ID=root;Password=;";
            try
            {
                return new MySqlConnection(connectionString);
            }
            catch (SqlException)
            {
                return new MySqlConnection();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }

        public DataContext()
        {
            this.getConnection();
        }
    }
}