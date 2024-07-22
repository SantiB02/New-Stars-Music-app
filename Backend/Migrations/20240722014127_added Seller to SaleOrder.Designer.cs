﻿// <auto-generated />
using System;
using Merchanmusic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Merchanmusic.Migrations
{
    [DbContext(typeof(MerchContext))]
    [Migration("20240722014127_added Seller to SaleOrder")]
    partial class addedSellertoSaleOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Merchanmusic.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "T-shirts"
                        },
                        new
                        {
                            Id = 2,
                            Name = "CDs"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Caps"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bags"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Posters"
                        });
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CreditCards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = "1234567891234567",
                            UserId = "default-identifier-3845746332"
                        });
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ArtistOrBand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DATETIME(0)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("DATETIME(0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(9,2)");

                    b.Property<int>("Sales")
                        .HasColumnType("int");

                    b.Property<string>("SellerId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("State")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SellerId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            ArtistOrBand = "ACDC",
                            CategoryId = 1,
                            Code = "1022",
                            CreationDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1518),
                            Description = "Remera ACDC algodón",
                            ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                            LastModifiedDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1532),
                            Name = "Remera ACDC",
                            Price = 12500.71m,
                            Sales = 237,
                            SellerId = "default-identifier-7771829382",
                            State = true,
                            Stock = 19
                        },
                        new
                        {
                            Id = 4,
                            ArtistOrBand = "Mozart",
                            CategoryId = 1,
                            Code = "18az4",
                            CreationDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1537),
                            Description = "Remera Mozart algodón",
                            ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                            LastModifiedDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1538),
                            Name = "Remera Mozart",
                            Price = 23763.34m,
                            Sales = 129,
                            SellerId = "default-identifier-7771829382",
                            State = true,
                            Stock = 24
                        },
                        new
                        {
                            Id = 5,
                            ArtistOrBand = "Beethoven",
                            CategoryId = 1,
                            Code = "17zz89",
                            CreationDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1540),
                            Description = "Remera Beethoven algodón",
                            ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                            LastModifiedDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1540),
                            Name = "Remera Beethoven",
                            Price = 12500.99m,
                            Sales = 83,
                            SellerId = "default-identifier-7771829382",
                            State = true,
                            Stock = 10
                        },
                        new
                        {
                            Id = 7,
                            ArtistOrBand = "LOVG",
                            CategoryId = 1,
                            Code = "ax34d",
                            CreationDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1543),
                            Description = "Remera overside negra",
                            ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                            LastModifiedDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1543),
                            Name = "Remera LOVG",
                            Price = 13200.11m,
                            Sales = 421,
                            SellerId = "default-identifier-7771829382",
                            State = true,
                            Stock = 15
                        },
                        new
                        {
                            Id = 8,
                            ArtistOrBand = "Flo Rida",
                            CategoryId = 2,
                            Code = "e52x6",
                            CreationDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1545),
                            Description = "Flo Rida's Wild Ones CD with his greatest hits!",
                            ImageLink = "https://merchbar.imgix.net/product/cdified/upc/34/075678833403.jpg?q=40&auto=compress,format&w=1400",
                            LastModifiedDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1546),
                            Name = "Flo Rida's Wild Ones CD",
                            Price = 19200.11m,
                            Sales = 129,
                            SellerId = "default-identifier-7771829382",
                            State = true,
                            Stock = 45
                        },
                        new
                        {
                            Id = 9,
                            ArtistOrBand = "David Guetta",
                            CategoryId = 3,
                            Code = "45hgr",
                            CreationDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1548),
                            Description = "Amazing David Guetta cap!",
                            ImageLink = "https://ih1.redbubble.net/image.3597046453.2550/ssrco,baseball_cap,product,000000:44f0b734a5,front_three_quarter,wide_portrait,750x1000-bg,f8f8f8.jpg",
                            LastModifiedDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1548),
                            Name = "David Guetta cap",
                            Price = 10700.13m,
                            Sales = 341,
                            SellerId = "default-identifier-7771829382",
                            State = true,
                            Stock = 34
                        },
                        new
                        {
                            Id = 10,
                            ArtistOrBand = "Avicii",
                            CategoryId = 4,
                            Code = "46as3",
                            CreationDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1551),
                            Description = "great and light Avicii bag!",
                            ImageLink = "https://ih1.redbubble.net/image.1091821770.3226/drawstring_bag,x750-pad,750x1000,f8f8f8.u2.jpg",
                            LastModifiedDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1551),
                            Name = "Avicii bag",
                            Price = 15900.45m,
                            Sales = 128,
                            SellerId = "default-identifier-7771829382",
                            State = true,
                            Stock = 12
                        },
                        new
                        {
                            Id = 11,
                            ArtistOrBand = "Coldplay",
                            CategoryId = 5,
                            Code = "76fg1",
                            CreationDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1553),
                            Description = "Really colorful Coldplay poster!",
                            ImageLink = "https://acdn.mitiendanube.com/stores/001/113/338/products/coldplay11-d0585db969184a7c0716063455586064-640-0.jpg",
                            LastModifiedDate = new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1554),
                            Name = "Coldplay poster",
                            Price = 8450.99m,
                            Sales = 451,
                            SellerId = "default-identifier-7771829382",
                            State = true,
                            Stock = 45
                        });
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.SaleOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Completed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME(0)");

                    b.Property<string>("OrderCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SellerId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("State")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Total")
                        .HasColumnType("DECIMAL(9,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("SellerId");

                    b.ToTable("SaleOrders");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.SaleOrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SaleOrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleOrderId");

                    b.ToTable("SaleOrderLines");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Apartment")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("State")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("WaitingValidation")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Role").HasValue("User");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.Admin", b =>
                {
                    b.HasBaseType("Merchanmusic.Data.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = "default-identifier-0012827345",
                            Email = "bdiaz@gmail.com",
                            State = true,
                            WaitingValidation = false
                        });
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.Client", b =>
                {
                    b.HasBaseType("Merchanmusic.Data.Entities.User");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Id = "default-identifier-3845746332",
                            Address = "Rivadavia 111",
                            Apartment = "8A",
                            City = "Rosario",
                            Country = "Argentina",
                            Email = "leomattsantana@gmail.com",
                            Phone = "+5493416271920",
                            PostalCode = "S2000",
                            State = true,
                            WaitingValidation = false
                        },
                        new
                        {
                            Id = "default-identifier-945711463132",
                            Address = "J.b.justo 111",
                            City = "Rosario",
                            Country = "Argentina",
                            Email = "santi@gmail.com",
                            Phone = "+5493413457612",
                            PostalCode = "S2000",
                            State = true,
                            WaitingValidation = false
                        },
                        new
                        {
                            Id = "default-identifier-73619823",
                            Address = "San Martin 111",
                            Apartment = "7B",
                            City = "Rosario",
                            Country = "Argentina",
                            Email = "jgarcia@gmail.com",
                            Phone = "+5493415678119",
                            PostalCode = "S2000",
                            State = true,
                            WaitingValidation = false
                        });
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.Seller", b =>
                {
                    b.HasBaseType("Merchanmusic.Data.Entities.User");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Seller");

                    b.HasData(
                        new
                        {
                            Id = "default-identifier-7771829382",
                            Address = "San Martin 111",
                            City = "Rosario",
                            Country = "Argentina",
                            Email = "katyperry@gmail.com",
                            Phone = "+5493416781203",
                            PostalCode = "S2000",
                            State = true,
                            WaitingValidation = false,
                            BankAccountNumber = "378364817263174"
                        });
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.CreditCard", b =>
                {
                    b.HasOne("Merchanmusic.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.Products.Product", b =>
                {
                    b.HasOne("Merchanmusic.Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Merchanmusic.Data.Entities.Seller", "Seller")
                        .WithMany("Products")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.SaleOrder", b =>
                {
                    b.HasOne("Merchanmusic.Data.Entities.User", "Client")
                        .WithMany("SaleOrders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Merchanmusic.Data.Entities.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.SaleOrderLine", b =>
                {
                    b.HasOne("Merchanmusic.Data.Entities.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Merchanmusic.Data.Entities.SaleOrder", null)
                        .WithMany("SaleOrderLines")
                        .HasForeignKey("SaleOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.SaleOrder", b =>
                {
                    b.Navigation("SaleOrderLines");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.User", b =>
                {
                    b.Navigation("SaleOrders");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.Seller", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
