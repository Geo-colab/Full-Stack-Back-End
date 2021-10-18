using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStack.Data.Migrations
{
    public partial class cloneupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Seller");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Seller",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Seller",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Seller");

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Seller",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Seller",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "SellerId");

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "AdvertDetails", "AdvertHead", "AdvertState", "CityId", "Price", "ProvinceId", "UserId" },
                values: new object[] { 1, "A large house with 3 bedrooms", "Palace in Verce", "Live", 3, 800000.00m, 2, 2 });
        }
    }
}
