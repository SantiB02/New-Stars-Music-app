using Merchanmusic.Data;
using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Entities.Products;
using Merchanmusic.Data.Models;
using Merchanmusic.Services.Interfaces;

namespace Merchanmusic.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly MerchContext _context;

        public ProductService(MerchContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product? GetProductByName(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name);
        }

        public int CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return (product.Id);
        }

        // Retorna true si se compraron todos los productos con éxito, false si algún producto no tiene stock suficiente o null si la lista de productos o alguno no existe:
        public bool? BuyProducts(List<ProductBuyOrder> buyOrders)
        {
            if (buyOrders.Count > 0)
            {
                _context.Database.BeginTransaction();
                foreach (ProductBuyOrder buyOrder in buyOrders)
                {
                    Product? product = _context.Products.FirstOrDefault(p => p.Id == buyOrder.Id);
                    if (product != null)
                    {
                        if (product.Stock >= buyOrder.QuantityToBuy)
                        {
                            product.Stock -= buyOrder.QuantityToBuy;
                            product.Sales += buyOrder.QuantityToBuy;
                            _context.SaveChanges();
                        }
                        else
                        {
                            _context.Database.RollbackTransaction();
                            return false; // el producto no tiene stock suficiente así que frenamos la iteración y salimos del método
                        }
                    }
                    else return null; // el producto no existe
                }
                _context.Database.CommitTransaction();
                return true; // sólo cuando todos los productos fueron comprados retornamos true
            }
            else return null; // la lista de productos a comprar está vacía
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = _context.Products.SingleOrDefault(p => p.Id == id);

            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                _context.SaveChanges();
            }
        }

        public void UpdateProduct(ProductUpdateDto productUpdateDto)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productUpdateDto.ProductId);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            if (product.SellerId != productUpdateDto.SellerId)
            {
                throw new Exception("SellerId mismatch");
            }

            product.Name = productUpdateDto.Name;
            product.Description = productUpdateDto.Description;
            product.Price = productUpdateDto.Price;
            product.Stock = productUpdateDto.Stock;
            product.CategoryId = productUpdateDto.CategoryId;
            product.ImageLink = productUpdateDto.ImageLink;

            _context.Products.Update(product);

            _context.SaveChanges();
        }

        public List<Product> GetProductBySeller(string sellerId)
        {
            return _context.Products.Where(x => x.SellerId == sellerId).ToList();
        }

        public void DeleteProductBySeller(int productId, string sellerId)
        {
            var productToDelete = _context.Products.SingleOrDefault(p => p.Id == productId);

            if (productToDelete == null)
            {
                throw new Exception("Product not found");
            }

            if (productToDelete.SellerId != sellerId)
            {
                throw new Exception("SellerId mismatch");
            }

            productToDelete.State = false;
                _context.Products.Update(productToDelete);
                _context.SaveChanges();
        }

        //public Product UpdateProductBySeller(ProductUpdateDto productDto, string sellerId)
        //{
        //    _context.Update(product);
        //    _context.SaveChanges();
        //    return product;
        //}

    }
}
