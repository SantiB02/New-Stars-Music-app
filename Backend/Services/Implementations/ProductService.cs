using Merchanmusic.Data;
using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Entities.Products;
using Merchanmusic.Data.Models;
using Merchanmusic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Merchanmusic.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly MerchContext _context;
        private const string ClientId = "f115d780765b543\t"; // Reemplaza con tu Client ID de Imgur
        private const string ClientSecret = "6978ebbc3c403f8640d75b622871b84093a8c94d\t"; // Reemplaza con tu Client Secret de Imgur

        public ProductService(MerchContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetFeaturedProducts(int minimumSales)
        {
            return _context.Products.Where(p => p.Sales >= minimumSales).Take(6).ToList();
        }

        public List<Product> GetProductsByCountryAndCategory(string country, int categoryId)
        {
            return _context.Products.Where(p => p.Seller.Country == country && p.CategoryId ==  categoryId).ToList();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product? GetProductByName(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name);
        }

        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
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

        public void UpdateProduct(ProductUpdateDto productUpdateDto, string sellerId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productUpdateDto.Id);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            if (product.SellerId != sellerId)
            {
                throw new Exception("SellerId mismatch");
            }

            Category category = _context.Categories.FirstOrDefault(c => c.Id == productUpdateDto.CategoryId);

            if (category != null)
            {
                product.Name = productUpdateDto.Name;
                product.Description = productUpdateDto.Description;
                product.ArtistOrBand = productUpdateDto.ArtistOrBand;
                product.Price = productUpdateDto.Price;
                product.Stock = productUpdateDto.Stock;
                product.Category = category;
                product.ImageLink = productUpdateDto.ImageLink;
                product.LastModifiedDate = DateTime.Now;

                _context.SaveChanges();
            } else
            {
                throw new Exception("Category not found");
            }            
        }

        public List<Product> GetProductBySeller(string sellerId)
        {
            return _context.Products.Where(x => x.SellerId == sellerId).ToList();
        }

        public void DeleteProduct(int productId, string sellerId)
        {
            Product productToDelete = _context.Products.SingleOrDefault(p => p.Id == productId);

            if (productToDelete == null)
            {
                throw new Exception("Product not found");
            }

            if (productToDelete.SellerId != sellerId)
            {
                throw new Exception("SellerId mismatch");
            }

            productToDelete.State = false;
            _context.SaveChanges();
        }

        public void RestoreProduct(int productId, string sellerId)
        {
            Product productToRestore = _context.Products.SingleOrDefault(p => p.Id == productId);
            if (productToRestore == null)
            {
                throw new Exception("Product not found");
            }

            if (productToRestore.SellerId != sellerId)
            {
                throw new Exception("SellerId mismatch");
            }

            productToRestore.State = true;
            _context.SaveChanges();
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {

           
            using (var client = new HttpClient())
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var content = new ByteArrayContent(stream.ToArray());
                content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                var base64String = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{ClientId}:{ClientSecret}"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);

                var response = await client.PostAsync("https://api.imgur.com/3/image", content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to upload to Imgur: " + response.ReasonPhrase);
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var imgurResponse = JsonConvert.DeserializeObject<ImgurResponse>(responseContent);

                return imgurResponse.Data.Link;
            }
        }



        private class ImgurResponse
        {
            public ImgurData Data { get; set; }
        }

        private class ImgurData
        {
            public string Link { get; set; }
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        //public Product UpdateProductBySeller(ProductUpdateDto productDto, string sellerId)
        //{
        //    _context.Update(product);
        //    _context.SaveChanges();
        //    return product;
        //}

    }
}
