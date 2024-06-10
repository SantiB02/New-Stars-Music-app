using Merchanmusic.Data.Entities.Products;

namespace Merchanmusic.Services.Interfaces
{
        public interface IProductService
        {
            List<Product> GetProducts();
            Product? GetProductById(int id);
            Product? GetProductByName(string name);
            int CreateProduct(Product product);
            void DeleteProduct(int id);
            Product UpdateProduct(Product product);
        }

}
