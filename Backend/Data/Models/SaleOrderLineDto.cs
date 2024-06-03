namespace Merchanmusic.Data.Models
{
    public class SaleOrderLineDto
    {
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductId { get; set; }
        public int SaleOrderId { get; set; }
    }
}
