using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStack.Data.Migrations
{
    public partial class Seller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Cities_CityId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Provinces_ProvinceId",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_CityId",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_ProvinceId",
                table: "Adverts");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceId",
                table: "Adverts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    SellerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.SellerId);
                    table.ForeignKey(
                        name: "FK_Seller_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seller_UserId",
                table: "Seller",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceId",
                table: "Adverts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_CityId",
                table: "Adverts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_ProvinceId",
                table: "Adverts",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Cities_CityId",
                table: "Adverts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Provinces_ProvinceId",
                table: "Adverts",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
