using Microsoft.EntityFrameworkCore.Migrations;

namespace CESParcelDeliverySystem.Migrations
{
    public partial class ConnectionsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_Category_SizeCategoryId",
                table: "Pricing");

            migrationBuilder.DropIndex(
                name: "IX_Pricing_SizeCategoryId",
                table: "Pricing");

            migrationBuilder.DropColumn(
                name: "SizeCategoryId",
                table: "Pricing");

            migrationBuilder.AddColumn<string>(
                name: "SizeCategory",
                table: "Pricing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Moves",
                table: "Connection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TransportationMode",
                table: "Connection",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeCategory",
                table: "Pricing");

            migrationBuilder.DropColumn(
                name: "Moves",
                table: "Connection");

            migrationBuilder.DropColumn(
                name: "TransportationMode",
                table: "Connection");

            migrationBuilder.AddColumn<int>(
                name: "SizeCategoryId",
                table: "Pricing",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pricing_SizeCategoryId",
                table: "Pricing",
                column: "SizeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_Category_SizeCategoryId",
                table: "Pricing",
                column: "SizeCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
