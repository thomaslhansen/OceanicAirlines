using Microsoft.EntityFrameworkCore.Migrations;

namespace CESParcelDeliverySystem.Migrations
{
    public partial class NewOrderCostumerRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CostumerEmail",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CostumerName",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostumerEmail",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CostumerName",
                table: "Order");
        }
    }
}
