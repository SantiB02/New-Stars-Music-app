using Merchanmusic.Data.Entities;
using Merchanmusic.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merchanmusic.Data.Models
{
    public class saleOrderCreateDto
    {
        public ICollection<SaleOrderLineCreateDto> SaleOrderLines { get; set; } = new List<SaleOrderLineCreateDto>();
         public int ClientId { get; set; }
        // public PaymentMethodEnum PaymentMethod { get; set; }
    }
}
