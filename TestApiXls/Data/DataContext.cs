using System.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestApiXls.Models;

using MySql.Data.MySqlClient;

namespace TestApiXls.Data
{
    public class DataContext : DbContext
    {
        private object connection;

        public DbSet<Address> addresses { get; set; }
        public DbSet<AddressInfo> addressInfos { get; set; }
        public DbSet<BcDataExt> bcDataExts { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Label> labels { get; set; }
        public DbSet<MultiShipment> multiShipments { get; set; }
        public DbSet<MultiShipmentBc> multiShipmentBcs { get; set; }
        public DbSet<ParcelInfo> parcelInfos { get; set; }
        public DbSet<ParcelInfoSin> parcelInfoSins { get; set; }
        public DbSet<ParcelNumber> parcelNumber { get; set; }
        public DbSet<Shipment> shippingDatas { get; set; }
        public DbSet<ShipmentBc> shipmentBcs { get; set; }
        public DbSet<Models.Type> types { get; set; }

        public object getConnection()
        {
            return connection;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }



        DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var builder = WebApplication.CreateBuilder();
            var contextBuilder = new DbContextOptionsBuilder<DataContext>();
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            connection = new MySqlConnection(connectionString);
        }
    }
}