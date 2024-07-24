using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Entities.Products;
using Merchanmusic.Data.Models;

namespace Merchanmusic.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        public List<Product> GetFeaturedProducts(int minimumSales);
        public List<Product> GetProductsByCountryAndCategory(string country, int categoryId);
        Product? GetProductById(int id);
        Product? GetProductByName(string name);
        Product CreateProduct(Product product);
        public bool? BuyProducts(List<ProductBuyOrder> buyOrders);
        void DeleteProduct(int productId, string sellerId);
        void RestoreProduct(int productId, string sellerId);
        List<Product> GetProductBySeller(string sellerId);
        void UpdateProduct(ProductUpdateDto productUpdateDto, string sellerId);
        Task<string> UploadImageAsync(IFormFile file);
        Task<ICollection<Category>> GetCategoriesAsync();
    }
}
