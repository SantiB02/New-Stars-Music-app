﻿using Merchanmusic.Data.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Merchanmusic.Data.Entities
{
    public class SaleOrderLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal Total { get; set; } 
        [ForeignKey("SaleOrderId")]
        public SaleOrder SaleOrder { get; set; }
        public int SaleOrderId { get; set; }
    }
}
