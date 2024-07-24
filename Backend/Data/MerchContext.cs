using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Entities.Products;
using Merchanmusic.Data.Payments;
using Merchanmusic.Enums;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Merchanmusic.Data
{
    public class MerchContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SaleOrderLine> SaleOrderLines { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }

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

            modelBuilder.Entity<Payment>().HasDiscriminator(p => p.PaymentMethod)
                .HasValue<CreditCardPayment>("Credit Card")
                .HasValue<BankTransferPayment>("Bank Transfer");

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

            modelBuilder.Entity<Message>().HasData(
                new Message
                {
                    MessageBody = "Bienvenido a nuestro sitio",
                    LastModifiedDate = DateTime.Now,
                    CreationDate = DateTime.Now,
                    Id = 1
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

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("DECIMAL(9, 2)");

            modelBuilder.Entity<CreditCardPayment>()
                .Property(ccp => ccp.AmountPerInstallment)
                .HasColumnType("DECIMAL(9, 2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.Date)
                .HasColumnType("DATETIME(0)");

            modelBuilder.Entity<Product>()
                .Property(p => p.CreationDate)
                .HasColumnType("DATETIME(0)");
            modelBuilder.Entity<Product>()
                .Property(p => p.LastModifiedDate)
                .HasColumnType("DATETIME(0)");

            modelBuilder.Entity<SaleOrder>()
                .Property(so => so.Date)
                .HasColumnType("DATETIME(0)");

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "T-shirts"
                },
                new Category
                {
                    Id = 2,
                    Name = "CDs"
                },
                new Category
                {
                    Id = 3,
                    Name = "Caps"
                },
                new Category
                {
                    Id = 4,
                    Name = "Bags"
                },
                new Category
                {
                    Id = 5,
                    Name = "Posters"
                }
                );

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
                    CategoryId = 1,
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
                    CategoryId = 1,
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
                    CategoryId = 1,
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
                    CategoryId = 1,
                    ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                    SellerId = "default-identifier-7771829382"
                },
                
                new Product
                {
                    Id = 8,
                    Name = "Flo Rida's Wild Ones CD",
                    Description = "Flo Rida's Wild Ones CD with his greatest hits!",
                    ArtistOrBand = "Flo Rida",
                    Code = "e52x6",
                    Price = 19200.11M,
                    Stock = 45,
                    Sales = 129,
                    CategoryId = 2,
                    ImageLink = "https://merchbar.imgix.net/product/cdified/upc/34/075678833403.jpg?q=40&auto=compress,format&w=1400",
                    SellerId = "default-identifier-7771829382"
                },
                
                new Product
                {
                    Id = 9,
                    Name = "David Guetta cap",
                    Description = "Amazing David Guetta cap!",
                    ArtistOrBand = "David Guetta",
                    Code = "45hgr",
                    Price = 10700.13M,
                    Stock = 34,
                    Sales = 341,
                    CategoryId = 3,
                    ImageLink = "https://ih1.redbubble.net/image.3597046453.2550/ssrco,baseball_cap,product,000000:44f0b734a5,front_three_quarter,wide_portrait,750x1000-bg,f8f8f8.jpg",
                    SellerId = "default-identifier-7771829382"
                },
                
                new Product
                {
                    Id = 10,
                    Name = "Avicii bag",
                    Description = "great and light Avicii bag!",
                    ArtistOrBand = "Avicii",
                    Code = "46as3",
                    Price = 15900.45M,
                    Stock = 12,
                    Sales = 128,
                    CategoryId = 4,
                    ImageLink = "https://ih1.redbubble.net/image.1091821770.3226/drawstring_bag,x750-pad,750x1000,f8f8f8.u2.jpg",
                    SellerId = "default-identifier-7771829382"
                },
                
                new Product
                {
                    Id = 11,
                    Name = "Coldplay poster",
                    Description = "Really colorful Coldplay poster!",
                    ArtistOrBand = "Coldplay",
                    Code = "76fg1",
                    Price = 8450.99M,
                    Stock = 45,
                    Sales = 451,
                    CategoryId = 5,
                    ImageLink = "https://acdn.mitiendanube.com/stores/001/113/338/products/coldplay11-d0585db969184a7c0716063455586064-640-0.jpg",
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

            // Relación entre Producto y Categoría
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

            // Relación entre Cliente y OrdenDeVenta (uno a muchos)
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

            // Relación entre pago y pagador
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Payer)
                .WithMany()
                .HasForeignKey(p => p.PayerId);

            // Relación entre pago y cobrador
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Receiver)
                .WithMany()
                .HasForeignKey(p => p.ReceiverId);
        }
    }

}
 
