﻿// <auto-generated />
using System;
using Merchanmusic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Merchanmusic.Migrations
{
    [DbContext(typeof(MerchContext))]
    partial class MerchContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Merchanmusic.Data.Entities.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

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
                        .HasColumnType("DECIMAL(7,2)");

                    b.Property<bool>("State")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            ArtistId = 5,
                            Category = "T-shirt",
                            Code = "1022",
                            CreationDate = new DateTime(2024, 6, 26, 23, 30, 4, 76, DateTimeKind.Local).AddTicks(3915),
                            Description = "Remera ACDC algodón",
                            ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                            LastModifiedDate = new DateTime(2024, 6, 26, 23, 30, 4, 76, DateTimeKind.Local).AddTicks(3926),
                            Name = "Remera ACDC",
                            Price = 12500m,
                            State = true,
                            Stock = 10
                        },
                        new
                        {
                            Id = 7,
                            ArtistId = 5,
                            Category = "T-shirt",
                            Code = "1021",
                            CreationDate = new DateTime(2024, 6, 26, 23, 30, 4, 76, DateTimeKind.Local).AddTicks(3938),
                            Description = "Remera overside negra",
                            ImageLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529",
                            LastModifiedDate = new DateTime(2024, 6, 26, 23, 30, 4, 76, DateTimeKind.Local).AddTicks(3939),
                            Name = "Remera LOVG",
                            Price = 13200m,
                            State = true,
                            Stock = 15
                        });
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.SaleOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<bool>("Completed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("OrderCode")
                        .HasColumnType("char(36)");

                    b.Property<bool>("State")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("SaleOrders");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.SaleOrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOrdered")
                        .HasColumnType("int");

                    b.Property<int>("SaleOrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleOrderId");

                    b.ToTable("SaleOrderLines");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("State")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.Admin", b =>
                {
                    b.HasBaseType("Merchanmusic.Data.Entities.User");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Admin_Role");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Email = "bdiaz@gmail.com",
                            LastName = "Bruno",
                            Name = "Diaz",
                            Password = "123456",
                            State = true,
                            UserName = "bdiaz",
                            UserType = "Client",
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.Artist", b =>
                {
                    b.HasBaseType("Merchanmusic.Data.Entities.User");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Artist");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Email = "katyperry@gmail.com",
                            LastName = "Perry",
                            Name = "Katy",
                            Password = "345",
                            State = true,
                            UserName = "katyp",
                            UserType = "Client",
                            Role = "Artist"
                        });
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.Client", b =>
                {
                    b.HasBaseType("Merchanmusic.Data.Entities.User");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Rivadavia 111",
                            Email = "ngomez@gmail.com",
                            LastName = "Gomez",
                            Name = "Nicolas",
                            Password = "123456",
                            State = true,
                            UserName = "ngomez_cliente",
                            UserType = "Client"
                        },
                        new
                        {
                            Id = 2,
                            Address = "J.b.justo 111",
                            Email = "Jperez@gmail.com",
                            LastName = "Perez",
                            Name = "Juan",
                            Password = "123456",
                            State = true,
                            UserName = "jperez",
                            UserType = "Client"
                        },
                        new
                        {
                            Id = 3,
                            Address = "San Martin 111",
                            Email = "jgarcia@gmail.com",
                            LastName = "Garcia",
                            Name = "Jose",
                            Password = "123456",
                            State = true,
                            UserName = "jgarcia",
                            UserType = "Client"
                        });
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.Products.Product", b =>
                {
                    b.HasOne("Merchanmusic.Data.Entities.Artist", "Artist")
                        .WithMany("Products")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.SaleOrder", b =>
                {
                    b.HasOne("Merchanmusic.Data.Entities.Client", "Client")
                        .WithMany("SaleOrders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.SaleOrderLine", b =>
                {
                    b.HasOne("Merchanmusic.Data.Entities.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Merchanmusic.Data.Entities.SaleOrder", "SaleOrder")
                        .WithMany("SaleOrderLines")
                        .HasForeignKey("SaleOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SaleOrder");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.SaleOrder", b =>
                {
                    b.Navigation("SaleOrderLines");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.Artist", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Merchanmusic.Data.Entities.Client", b =>
                {
                    b.Navigation("SaleOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
