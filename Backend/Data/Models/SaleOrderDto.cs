using Merchanmusic.Data.Entities;
using Merchanmusic.Enums;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merchanmusic.Data.Models
{
    public class SaleOrderDto
    {
        public string ClientId { get; set; }
        public ICollection<SaleOrderLineDto> Lines { get; set; }
        public decimal Total {  get; set; }
    }
}
