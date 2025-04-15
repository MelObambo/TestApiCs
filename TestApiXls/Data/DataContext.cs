using Microsoft.EntityFrameworkCore;
using TestApiXls.Models;

namespace TestApiXls.Data
{
    public class DataContext : DbContext
    {
        DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<Models.Address> adresses { get; set; }
        public DbSet<Models.AddressInfo> addressInfos { get; set; }
        public DbSet<Models.BcDataExt> bcDataExts { get; set; }
        public DbSet<Models.Customer> customers { get; set; }
        public DbSet<Models.Label> labels { get; set; }
        public DbSet<Models.MultiShipment> multiShipments { get; set; }
        public DbSet<Models.MultiShipmentBc> multiShipmentBcs { get; set; }
        public DbSet<Models.ParcelInfo> parcelInfos { get; set; }
        public DbSet<Models.ParcelInfoSin> parcelInfoSins { get; set; }
        public DbSet<Models.ParcelNumber> parcelNumber { get; set; }
        public DbSet<Models.Shipment> shippingDatas { get; set; }
        public DbSet<Models.ShipmentBc> shipmentBcs { get; set; }
        public DbSet<Models.Type> types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}