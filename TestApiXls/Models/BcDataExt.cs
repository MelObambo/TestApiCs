namespace TestApiXls.Models
{
    public class BcDataExt
    {
        public required int id { get; set; }
        public required string barCode { get; set; }
        public required string barCodeId { get; set; }
        public int barCodeSource { get; set; }
    }
}
