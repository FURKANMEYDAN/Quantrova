﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shop.Persistence.Context;

#nullable disable

namespace Shop.Persistence.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20241007191239_Implement-log-product-spesifications")]
    partial class Implementlogproductspesifications
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shop.Domain.Entities.About", b =>
                {
                    b.Property<int>("AboutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AboutId"));

                    b.HasKey("AboutId");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Announcement", b =>
                {
                    b.Property<int>("AnnouncementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnnouncementId"));

                    b.HasKey("AnnouncementId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Basket", b =>
                {
                    b.Property<int>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BasketId"));

                    b.HasKey("BasketId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BrandId"));

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Shop.Domain.Entities.CategoryDetail", b =>
                {
                    b.Property<int>("CategoryDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryDetailId"));

                    b.Property<string>("CategoryDetailName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryDetailId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryDetails");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ContactId"));

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DiscountId"));

                    b.HasKey("DiscountId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Exception")
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shop.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderItemId"));

                    b.HasKey("OrderItemId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryDetailId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("numeric");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryDetailId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shop.Domain.Entities.ProductComment", b =>
                {
                    b.Property<int>("ProductCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductCommentId"));

                    b.HasKey("ProductCommentId");

                    b.ToTable("ProductComments");
                });

            modelBuilder.Entity("Shop.Domain.Entities.ProductDetail", b =>
                {
                    b.Property<string>("ProductDetailId")
                        .HasColumnType("text");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductId1")
                        .HasColumnType("integer");

                    b.Property<string>("ProductInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProductDetailId");

                    b.HasIndex("ProductId1");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("Shop.Domain.Entities.ProductImage", b =>
                {
                    b.Property<string>("ProductImageId")
                        .HasColumnType("text");

                    b.Property<string>("Image1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image3")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductId1")
                        .HasColumnType("integer");

                    b.HasKey("ProductImageId");

                    b.HasIndex("ProductId1");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Shop.Domain.Entities.CategoryDetail", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Category", null)
                        .WithMany("CategoryDetail")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product", b =>
                {
                    b.HasOne("Shop.Domain.Entities.CategoryDetail", "CategoryDetail")
                        .WithMany("Products")
                        .HasForeignKey("CategoryDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("CategoryDetail");
                });

            modelBuilder.Entity("Shop.Domain.Entities.ProductDetail", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shop.Domain.Entities.ProductImage", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Category", b =>
                {
                    b.Navigation("CategoryDetail");
                });

            modelBuilder.Entity("Shop.Domain.Entities.CategoryDetail", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
