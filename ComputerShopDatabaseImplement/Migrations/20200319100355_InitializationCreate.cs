using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerShopDatabaseImplement.Migrations
{
    public partial class InitializationCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Assemblies_AssemblyId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AssemblyId",
                table: "Orders");

            migrationBuilder.AlterColumn<decimal>(
                name: "Sum",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AssemblyId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Assemblies",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderId",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Assemblies_OrderId",
                table: "Orders",
                column: "OrderId",
                principalTable: "Assemblies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Assemblies_OrderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "Sum",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "AssemblyId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Assemblies",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AssemblyId",
                table: "Orders",
                column: "AssemblyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Assemblies_AssemblyId",
                table: "Orders",
                column: "AssemblyId",
                principalTable: "Assemblies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
