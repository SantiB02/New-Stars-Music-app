using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Entities.Products;
using Merchanmusic.Enums;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Merchanmusic.Data
{
    public class MerchContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleOrderLine> SaleOrderLines { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        public MerchContext(DbContextOptions<MerchContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.Role)
                .HasValue<Client>("Client")
                .HasValue<Seller>("Seller")
                .HasValue<Admin>("Admin");

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Email = "leomattsantana@gmail.com",
                    Address = "Rivadavia 111",
                    City = "Rosario",
                    PostalCode = "S2000",
                    Apartment = "8A",
                    Phone = "+5493416271920",
                    Country = "Argentina",
                    Id = "default-identifier-3845746332",
                },
                new Client
                {
                    Email = "santi@gmail.com",
                    Address = "J.b.justo 111",
                    City = "Rosario",
                    PostalCode = "S2000",
                    Phone = "+5493413457612",
                    Country = "Argentina",
                    Id = "default-identifier-945711463132",
                },
                new Client
                {
                    Email = "jgarcia@gmail.com",
                    Address = "San Martin 111",
                    City = "Rosario",
                    PostalCode = "S2000",
                    Apartment = "7B",
                    Phone = "+5493415678119",
                    Country = "Argentina",
                    Id = "default-identifier-73619823",
                });

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Email = "bdiaz@gmail.com",
                    Id = "default-identifier-0012827345",
                });

            modelBuilder.Entity<Seller>().HasData(
            new Seller
            {
                Email = "katyperry@gmail.com",
                Id = "default-identifier-7771829382",
                Address = "San Martin 111",
                City = "Rosario",
                PostalCode = "S2000",
                Phone = "+5493416781203",
                Country = "Argentina",
                BankAccountNumber = "378364817263174"
            });

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("DECIMAL(9, 2)");

            modelBuilder.Entity<SaleOrder>()
                .Property(so => so.Total)
                .HasColumnType("DECIMAL(9, 2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.CreationDate)
                .HasColumnType("DATETIME(0)");
            modelBuilder.Entity<Product>()
                .Property(p => p.LastModifiedDate)
                .HasColumnType("DATETIME(0)");

            modelBuilder.Entity<SaleOrder>()
                .Property(so => so.Date)
                .HasColumnType("DATETIME(0)");

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 2,
                    Name = "Remera ACDC",
                    Description ="Remera ACDC algodón",
                    ArtistOrBand = "ACDC",
                    Code ="1022",
                    Price = 12500.71M,
                    Stock = 19,
                    Sales = 237,
                    Category = "T-shirt",
                    ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                    SellerId = "default-identifier-7771829382"


                },
                new Product
                {
                    Id = 4,
                    Name = "Remera Mozart",
                    Description = "Remera Mozart algodón",
                    ArtistOrBand = "Mozart",
                    Code = "18az4",
                    Price = 23763.34M,
                    Stock = 24,
                    Sales = 129,
                    Category = "T-shirt",
                    ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                    SellerId = "default-identifier-7771829382"

                },
                new Product
                {
                    Id = 5,
                    Name = "Remera Beethoven",
                    Description = "Remera Beethoven algodón",
                    ArtistOrBand = "Beethoven",
                    Code = "17zz89",
                    Price = 12500.99M,
                    Stock = 10,
                    Sales = 83,
                    Category = "T-shirt",
                    ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                    SellerId = "default-identifier-7771829382"

                },
                new Product
                {
                    Id = 7,
                    Name = "Remera LOVG",
                    Description ="Remera overside negra",
                    ArtistOrBand = "LOVG",
                    Code ="ax34d",
                    Price = 13200.11M,
                    Stock = 15,
                    Sales = 421,
                    Category = "T-shirt",
                    ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                    SellerId = "default-identifier-7771829382"
                });

            modelBuilder.Entity<CreditCard>()
                .HasData(
                new CreditCard
                {
                    Id = 1,
                    Number = "1234567891234567",
                    UserId = "default-identifier-3845746332"
                });

            // // Relación entre Cliente y OrdenDeVenta (uno a muchos)
            modelBuilder.Entity<User>()
           .HasMany(c => c.SaleOrders)
           .WithOne(o => o.Client)
           .HasForeignKey(o => o.ClientId);

            // Relación entre OrdenDeVenta y LineaDeVenta (uno a muchos)
            modelBuilder.Entity<SaleOrder>()
                .HasMany(o => o.SaleOrderLines)
                .WithOne()
                .HasForeignKey(l => l.SaleOrderId);


            modelBuilder.Entity<SaleOrderLine>()
                .HasOne(sol => sol.Product)
                .WithMany() //vacío porque no me interesa establecer esa relación
                .HasForeignKey(sol => sol.ProductId);
                                                                              
            //Relación entre artista y producto
            modelBuilder.Entity<Seller>()
                .HasMany(u => u.Products)
                .WithOne(p => p.Seller)
                .HasForeignKey(f => f.SellerId);

        }
    }

}
 
