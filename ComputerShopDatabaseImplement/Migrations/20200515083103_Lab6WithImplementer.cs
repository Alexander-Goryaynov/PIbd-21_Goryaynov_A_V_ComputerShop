using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerShopDatabaseImplement.Migrations
{
    public partial class Lab6WithImplementer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImplementerFIO",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImplementerId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Implementers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(nullable: true),
                    WorkingTime = table.Column<int>(nullable: false),
                    PauseTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Implementers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ImplementerId",
                table: "Orders",
                column: "ImplementerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Implementers_ImplementerId",
                table: "Orders",
                column: "ImplementerId",
                principalTable: "Implementers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Implementers_ImplementerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Implementers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ImplementerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ImplementerFIO",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ImplementerId",
                table: "Orders");
        }
    }
}
