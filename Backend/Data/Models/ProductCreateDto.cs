using System.ComponentModel.DataAnnotations;

namespace Merchanmusic.Data.Models
{
    public class ProductCreatDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
