using Merchanmusic.Data.Entities;
using Merchanmusic.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merchanmusic.Data.Payments

{
    public abstract class Payment : IPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [ForeignKey("PayerId")]
        public Client Payer { get; set; }
        public string PayerId { get; set; }
        [ForeignKey("ReceiverId")]
        public Seller Receiver { get; set; }
        public string ReceiverId { get; set; }

        public virtual bool ProcessPayment(decimal amount)
        {
            // implementación default
            return true;
        }

        public virtual bool ProcessPayment(decimal amount, int installments)
        {
            // implementación default
            return true;
        }
    }

}
