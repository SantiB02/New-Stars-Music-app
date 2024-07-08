using Merchanmusic.Data.Entities;
using Merchanmusic.Enums;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merchanmusic.Data.Models
{
    public class SaleOrderDto
    {
        public ICollection<SaleOrderLineDto> LinesDto { get; set; }
        public decimal Total {  get; set; }
    }
}
