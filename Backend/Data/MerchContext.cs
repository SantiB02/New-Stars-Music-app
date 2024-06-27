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
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    LastName = "Gomez",
                    Name = "Nicolas",
                    Email = "ngomez@gmail.com",
                    UserName = "ngomez_cliente",
                    Password = "123456",
                    Address = "Rivadavia 111",
                    Id = 1
                },
                new Client
                {
                    LastName = "Perez",
                    Name = "Juan",
                    Email = "Jperez@gmail.com",
                    UserName = "jperez",
                    Password = "123456",
                    Address = "J.b.justo 111",
                    Id = 2
                },
                new Client
                {
                    LastName = "Garcia",
                    Name = "Jose",
                    Email = "jgarcia@gmail.com",
                    UserName = "jgarcia",
                    Password = "123456",
                    Address = "San Martin 111",
                    Id = 3
                });

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    LastName = "Bruno",
                    Name = "Diaz",
                    Email = "bdiaz@gmail.com",
                    UserName = "bdiaz",
                    Password = "123456",
                    Id = 4,
                    
                    Role = "admin"
                });

            modelBuilder.Entity<Artist>().HasData(
            new Artist
            {
                LastName = "Perry",
                Name = "Katy",
                Email = "katyperry@gmail.com",
                UserName = "katyp",
                Password = "345",
                Id = 5,
                Role = "Artist"
            });

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("DECIMAL(7, 2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.CreationDate)
                .HasColumnType("DATETIME(0)");
            modelBuilder.Entity<Product>()
                .Property(p => p.LastModifiedDate)
                .HasColumnType("DATETIME(0)");

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 6,
                    Name = "Remera ACDC",
                    Description ="Remera ACDC algodón",
                    Code="1022",
                    Price = 12500,
                    Stock = 10,
                    Category = "T-shirt",
                    ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                    ArtistId = 5

                },
                new Product
                {
                    Id = 7,
                    Name = "Remera LOVG",
                    Description ="Remera overside negra",
                    Code ="1021",
                    Price = 13200,
                    Stock = 15,
                    Category = "T-shirt",
                    ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                    ArtistId = 5
                });



            // // Relación entre Cliente y OrdenDeVenta (uno a muchos)
            modelBuilder.Entity<Client>()
           .HasMany(c => c.SaleOrders)
           .WithOne(o => o.Client)
           .HasForeignKey(o => o.ClientId);

            // Relación entre OrdenDeVenta y LineaDeVenta (uno a muchos)
            modelBuilder.Entity<SaleOrder>()
                .HasMany(o => o.SaleOrderLines)
                .WithOne(l => l.SaleOrder)
                .HasForeignKey(l => l.SaleOrderId);


            modelBuilder.Entity<SaleOrderLine>()
                .HasOne(sol => sol.Product)
                .WithMany() //vacío porque no me interesa establecer esa relación
                .HasForeignKey(sol => sol.ProductId);
                                                                              
            //Relación entre artista y producto
            modelBuilder.Entity<Artist>()
                .HasMany(u => u.Products)
                .WithOne(p => p.Artist)
                .HasForeignKey(f => f.ArtistId);

            base.OnModelCreating(modelBuilder);

        }
    }

}
 
