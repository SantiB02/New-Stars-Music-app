using System.ComponentModel.DataAnnotations.Schema;

namespace Merchanmusic.Data.Models
{
    public class SaleOrderUpdateDto
    {
        public ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();
        public PaymentMethodEnum PaymentMethod { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
