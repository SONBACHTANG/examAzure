namespace WebOrder.Models
{
    public class OrderViewModel
    {
        public string? ItemName { get; set; }
        public int ItemQty { get; set; }
        public string? OrderDelivery { get; set; }
        public string? OrderAddress { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
