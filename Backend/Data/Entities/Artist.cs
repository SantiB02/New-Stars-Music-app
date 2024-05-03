using Merchanmusic.Data.Entities.Products;

namespace Merchanmusic.Data.Entities
{
    public class Artist:User 
    {
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public string Role { get; set; } = "Artist";
    }
}
