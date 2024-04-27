using Merchanmusic.Data.Entities.Products;

namespace Merchanmusic.Data.Entities
{
    public class Artist
    {
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
