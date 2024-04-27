namespace Merchanmusic.Data.Models
{
    public class ProductUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; }

        //   public string ImageProduct { get; set; }
    }
}
