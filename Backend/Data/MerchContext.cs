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
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SaleOrderLine> SaleOrderLines { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        public MerchContext(DbContextOptions<MerchContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator<string>("Role")
                .HasValue<Client>("Client")
                .HasValue<Seller>("Seller")
                .HasValue<Admin>("Admin");

            modelBuilder.Entity<UserRole>().HasData(
               new UserRole
               {
                   Id = 1,
                   RoleName = "Client",
               },
               new UserRole
               {
                   Id = 2,
                   RoleName = "Seller",
               },
               new UserRole
               {
                   Id = 3,
                   RoleName = "Admin",
               }
               );

            modelBuilder.Entity<Client>().HasData(
                new Client
                {

                    Email = "leomattsantana@gmail.com",
                    Address = "Rivadavia 111",
                    Id = 1,
                    UserRoleId = (int)UserRoleEnum.Client
                },
                new Client
                {

                    Email = "santi@gmail.com",
                    Address = "J.b.justo 111",
                    Id = 2,
                    UserRoleId = (int)UserRoleEnum.Client
                },
                new Client
                {

                    Email = "jgarcia@gmail.com",
                    Address = "San Martin 111",
                    Id = 3,
                    UserRoleId = (int)UserRoleEnum.Client
                });

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Email = "bdiaz@gmail.com",
                    Address = "San Martin 135",
                    Id = 4,
                    UserRoleId = (int)UserRoleEnum.Admin
                });

            modelBuilder.Entity<Seller>().HasData(
            new Seller
            {

                Email = "katyperry@gmail.com",
                Id = 5,
                UserRoleId = (int)UserRoleEnum.Seller,
                Address = "San Martin 111",

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
                    Id = 2,
                    Name = "Remera ACDC",
                    Description ="Remera ACDC algodón",
                    Code="1022",
                    Price = 12500,
                    Stock = 10,
                    Category = "T-shirt",
                    ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                    SellerId = 5


                },
                new Product
                {
                    Id = 4,
                    Name = "Remera Mozart",
                    Description = "Remera Mozart algodón",
                    Code = "1022",
                    Price = 12500,
                    Stock = 10,
                    Category = "T-shirt",
                    ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                    SellerId = 5

                },
                new Product
                {
                    Id = 5,
                    Name = "Remera Beethoven",
                    Description = "Remera Beethoven algodón",
                    Code = "1022",
                    Price = 12500,
                    Stock = 10,
                    Category = "T-shirt",
                    ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                    SellerId = 5

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
                    SellerId = 5
                });



            // Relacion entre User y UserRole 
            modelBuilder.Entity<User>()
            .HasOne(u => u.UserRoleObject)
            .WithMany()
            .HasForeignKey(u => u.UserRoleId);

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
            modelBuilder.Entity<Seller>()
                .HasMany(u => u.Products)
                .WithOne(p => p.Seller)
                .HasForeignKey(f => f.SellerId);

        }
    }

}
 
