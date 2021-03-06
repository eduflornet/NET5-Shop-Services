// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopService.Api.ShoppingCart.Persistence;

namespace ShopService.Api.ShoppingCart.Migrations
{
    [DbContext(typeof(CartContext))]
    [Migration("20210821091419_InitialMigrationApiShoppingCart")]
    partial class InitialMigrationApiShoppingCart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("ShopService.Api.ShoppingCart.Model.CartSession", b =>
                {
                    b.Property<int>("CartSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.HasKey("CartSessionId");

                    b.ToTable("CartSession");
                });

            modelBuilder.Entity("ShopService.Api.ShoppingCart.Model.ShoppingCartSessionDetail", b =>
                {
                    b.Property<int>("ShoppingCartSessionDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CartSessionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("SelectedProduct")
                        .HasColumnType("text");

                    b.HasKey("ShoppingCartSessionDetailId");

                    b.HasIndex("CartSessionId");

                    b.ToTable("ShoppingCartSessionDetail");
                });

            modelBuilder.Entity("ShopService.Api.ShoppingCart.Model.ShoppingCartSessionDetail", b =>
                {
                    b.HasOne("ShopService.Api.ShoppingCart.Model.CartSession", "CartSession")
                        .WithMany("DetailList")
                        .HasForeignKey("CartSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CartSession");
                });

            modelBuilder.Entity("ShopService.Api.ShoppingCart.Model.CartSession", b =>
                {
                    b.Navigation("DetailList");
                });
#pragma warning restore 612, 618
        }
    }
}
