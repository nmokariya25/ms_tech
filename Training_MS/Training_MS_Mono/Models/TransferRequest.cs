namespace Training_MS_Mono.Models
{
    public class TransferRequest
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
