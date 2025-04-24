namespace TestApiXls.Models
{
    public class ParcelInfo
    {
        public required Parcel Parcel { get; set; }
        public required string BarCodeSource { get; set; }
        public required int BarcodeId { get; set; }
    }
}
