using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStack.Data.Migrations
{
    public partial class advertdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "AdvertDetails", "AdvertHead", "AdvertState", "City", "Price", "Province", "UserId" },
                values: new object[] { 1, "A large house with 3 bedrooms", "Palace in Verce", "Live", "Bloemfontein", 800000.00m, "Free State", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
