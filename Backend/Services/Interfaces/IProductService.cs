using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Entities.Products;
using Merchanmusic.Data.Models;

namespace Merchanmusic.Services.Interfaces
{
        public interface IProductService
        {
            List<Product> GetProducts();
            public List<Product> GetFeaturedProducts(int minimumSales);
            Product? GetProductById(int id);
            Product? GetProductByName(string name);
            int CreateProduct(Product product);
            public bool? BuyProducts(List<ProductBuyOrder> buyOrders);
            void DeleteProduct(int id);
            void DeleteProductBySeller(int productId, string sellerId);
            //Product UpdateProduct(Product product);
            List<Product> GetProductBySeller(string sellerId);
            void UpdateProduct(ProductUpdateDto productUpdateDto);
        }

}
