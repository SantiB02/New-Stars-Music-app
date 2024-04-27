using Merchanmusic.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Merchanmusic.Data.Models
{
    public class SaleOrderLineCreateDto
    {
        public int ProductId { get; set; }
        public int QuantityOrdered { get; set; }
        public int SaleOrderId { get; set; }

    }
}
