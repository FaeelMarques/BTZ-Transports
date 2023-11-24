using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTZTransports.Application.Migrations
{
    public partial class Adding_New_Fields_To_Fuel_Supply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalValueSupplied",
                table: "FuelSupplyHistory",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalValueSupplied",
                table: "FuelSupplyHistory");
        }
    }
}
