namespace Merchanmusic.Data.Models
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ArtistOrBand { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public string ImageLink { get; set; }
        public int CategoryId { get; set; }
    }
}
