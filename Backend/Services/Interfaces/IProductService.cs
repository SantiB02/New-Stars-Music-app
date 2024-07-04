using Merchanmusic.Data.Entities.Products;
using Merchanmusic.Data.Models;

namespace Merchanmusic.Services.Interfaces
{
        public interface IProductService
        {
            List<Product> GetProducts();
            Product? GetProductById(int id);
            Product? GetProductByName(string name);
            int CreateProduct(Product product);
            void DeleteProduct(int id, string sellerId);
            //Product UpdateProduct(Product product);
        List<Product> GetProductBySeller(string sellerId);
         void UpdateProduct(ProductUpdateDto productUpdateDto);
        }

}
