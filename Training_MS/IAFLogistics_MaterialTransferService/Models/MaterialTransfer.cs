namespace IAFLogistics_MaterialTransferService.Models
{
    public class MaterialTransfer
    {
        public int Id { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public DateTime TransferDate { get; set; }
        public string Status { get; set; }
    }
}
