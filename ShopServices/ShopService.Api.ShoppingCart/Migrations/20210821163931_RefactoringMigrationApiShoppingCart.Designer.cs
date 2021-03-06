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
    [Migration("20210821163931_RefactoringMigrationApiShoppingCart")]
    partial class RefactoringMigrationApiShoppingCart
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

            modelBuilder.Entity("ShopService.Api.ShoppingCart.Model.CartSessionDetail", b =>
                {
                    b.Property<int>("CartSessionDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CartSessionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("SelectedProduct")
                        .HasColumnType("text");

                    b.HasKey("CartSessionDetailId");

                    b.HasIndex("CartSessionId");

                    b.ToTable("CartSessionDetail");
                });

            modelBuilder.Entity("ShopService.Api.ShoppingCart.Model.CartSessionDetail", b =>
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
