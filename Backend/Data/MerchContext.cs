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
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<SaleOrderLine> SaleOrderLines { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }

        //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        public MerchContext(DbContextOptions<MerchContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);
        }
}
