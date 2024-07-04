using Merchanmusic.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Merchanmusic.Data.Models
{
    public class ProductCreateDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public string? Code { get; set; }
        public string? ImageLink { get; set; }
        public string? Category { get; set; }
        public string? SellerId { get; set; }
        public string? ArtistOrBand { get; set; }
    }
}
