using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Merchanmusic.Data.Entities.Products

{
    public class Product
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 50;
        public const int MinDescriptionLength = 20;
        public const int MaxDescriptionLength = 150;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ArtistOrBand {  get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public int Stock { get; set; }
        public int Sales {  get; set; } = 0;
        public decimal Price { get; set; }
        public string ImageLink { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool State { get; set; } = true; 
        //public Product() { }
        [ForeignKey("SellerId")]
        public Seller Seller { get; set; }
        public string SellerId {get; set; }
    }
}
