namespace Training_MS_Mono.Models
{
    public class DemandItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string Priority { get; set; }
        public string RequestedBy { get; set; }
        public DateTime DateRequested { get; set; }
        public string Status { get; set; }
    }
}
