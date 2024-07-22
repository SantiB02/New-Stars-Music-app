using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Merchanmusic.Data.Entities
{
    public class SaleOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();

        // public PaymentMethodEnum PaymentMethod { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Total { get; set; }

        [ForeignKey("ClientId")]
        public User Client { get; set; }
        public string ClientId { get; set; }
        [ForeignKey("SellerId")]
        public Seller Seller { get; set; }
        public string SellerId { get; set; }
        public bool Completed { get; set; } = false;
        public bool State { get; set; } = true; 
    }
}
