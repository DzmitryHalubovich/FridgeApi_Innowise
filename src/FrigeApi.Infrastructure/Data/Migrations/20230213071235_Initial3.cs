using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrigeApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FridgeProducts_Fridges_FridgeId",
                table: "FridgeProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeProducts_Products_ProductId",
                table: "FridgeProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FridgeProducts",
                table: "FridgeProducts");

            migrationBuilder.DropIndex(
                name: "IX_FridgeProducts_ProductId",
                table: "FridgeProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FridgeProducts");

            migrationBuilder.RenameTable(
                name: "FridgeProducts",
                newName: "FridgesProducts");

            migrationBuilder.RenameIndex(
                name: "IX_FridgeProducts_FridgeId",
                table: "FridgesProducts",
                newName: "IX_FridgesProducts_FridgeId");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "FridgesProducts",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FridgesProducts",
                table: "FridgesProducts",
                columns: new[] { "ProductId", "FridgeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FridgesProducts_Fridges_FridgeId",
                table: "FridgesProducts",
                column: "FridgeId",
                principalTable: "Fridges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgesProducts_Products_ProductId",
                table: "FridgesProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FridgesProducts_Fridges_FridgeId",
                table: "FridgesProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgesProducts_Products_ProductId",
                table: "FridgesProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FridgesProducts",
                table: "FridgesProducts");

            migrationBuilder.RenameTable(
                name: "FridgesProducts",
                newName: "FridgeProducts");

            migrationBuilder.RenameIndex(
                name: "IX_FridgesProducts_FridgeId",
                table: "FridgeProducts",
                newName: "IX_FridgeProducts_FridgeId");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "FridgeProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FridgeProducts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FridgeProducts",
                table: "FridgeProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeProducts_ProductId",
                table: "FridgeProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeProducts_Fridges_FridgeId",
                table: "FridgeProducts",
                column: "FridgeId",
                principalTable: "Fridges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeProducts_Products_ProductId",
                table: "FridgeProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
