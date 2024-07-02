using Merchanmusic.Data.Entities.Products;

namespace Merchanmusic.Data.Entities
{
    public class Seller : User 
    {
        public string? BankAccountNumber {  get; set; } 
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
