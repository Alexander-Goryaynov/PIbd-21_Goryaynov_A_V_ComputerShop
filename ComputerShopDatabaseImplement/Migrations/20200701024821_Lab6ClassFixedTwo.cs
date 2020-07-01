using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerShopDatabaseImplement.Migrations
{
    public partial class Lab6ClassFixedTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImplementerFIO",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImplementerFIO",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
