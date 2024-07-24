namespace Merchanmusic.Data.Models
{
    public class PaymentRequest
    {
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public int? Installments { get; set; }
    }
}
