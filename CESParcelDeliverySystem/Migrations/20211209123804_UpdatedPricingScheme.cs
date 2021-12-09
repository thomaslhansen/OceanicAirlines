using Microsoft.EntityFrameworkCore.Migrations;

namespace CESParcelDeliverySystem.Migrations
{
    public partial class UpdatedPricingScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_Category_CategoryId",
                table: "Pricing");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Pricing");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Pricing",
                newName: "SizeCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Pricing_CategoryId",
                table: "Pricing",
                newName: "IX_Pricing_SizeCategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Pricing",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "LatestShippingPrice",
                table: "Pricing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LatestTruckingPrice",
                table: "Pricing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WeightCategory",
                table: "Pricing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_Category_SizeCategoryId",
                table: "Pricing",
                column: "SizeCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_Category_SizeCategoryId",
                table: "Pricing");

            migrationBuilder.DropColumn(
                name: "LatestShippingPrice",
                table: "Pricing");

            migrationBuilder.DropColumn(
                name: "LatestTruckingPrice",
                table: "Pricing");

            migrationBuilder.DropColumn(
                name: "WeightCategory",
                table: "Pricing");

            migrationBuilder.RenameColumn(
                name: "SizeCategoryId",
                table: "Pricing",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Pricing_SizeCategoryId",
                table: "Pricing",
                newName: "IX_Pricing_CategoryId");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Pricing",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Pricing",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_Category_CategoryId",
                table: "Pricing",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
