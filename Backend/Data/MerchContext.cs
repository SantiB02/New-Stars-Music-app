using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Merchanmusic.Data
{
    public class MerchContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
       // public DbSet<SaleOrder> SaleOrders { get; set; }
       
    }
}
