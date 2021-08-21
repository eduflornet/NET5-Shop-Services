using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ShopService.Api.ShoppingCart.Migrations
{
    public partial class InitialMigrationApiShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartSession",
                columns: table => new
                {
                    CartSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartSession", x => x.CartSessionId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartSessionDetail",
                columns: table => new
                {
                    ShoppingCartSessionDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SelectedProduct = table.Column<string>(type: "text", nullable: true),
                    CartSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartSessionDetail", x => x.ShoppingCartSessionDetailId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartSessionDetail_CartSession_CartSessionId",
                        column: x => x.CartSessionId,
                        principalTable: "CartSession",
                        principalColumn: "CartSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartSessionDetail_CartSessionId",
                table: "ShoppingCartSessionDetail",
                column: "CartSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartSessionDetail");

            migrationBuilder.DropTable(
                name: "CartSession");
        }
    }
}
