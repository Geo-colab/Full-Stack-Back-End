using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStack.Data.Migrations
{
    public partial class PriceIntervals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceIntervals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceIntervalValue = table.Column<decimal>(nullable: false),
                    PriceIntervalDisplay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceIntervals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PriceIntervals",
                columns: new[] { "Id", "PriceIntervalDisplay", "PriceIntervalValue" },
                values: new object[,]
                {
                    { 1, "R10,000 - R4,999,999", 10000m },
                    { 18, "R85,000,000 - R89,999,999", 85000000m },
                    { 17, "R80,000,000 - R84,999,999", 80000000m },
                    { 16, "R75,000,000 - R79,999,999", 75000000m },
                    { 15, "R70,000,000 - R74,999,999", 70000000m },
                    { 14, "R65,000,000 - R69,999,999", 65000000m },
                    { 13, "R60,000,000 - R64,999,999", 60000000m },
                    { 12, "R55,000,000 - R59,999,999", 55000000m },
                    { 11, "R50,000,000 - R54,999,999", 50000000m },
                    { 10, "R45,000,000 - R49,999,999", 45000000m },
                    { 9, "R40,000,000 - R44,999,999", 40000000m },
                    { 8, "R35,000,000 - R39,999,999", 35000000m },
                    { 7, "R30,000,000 - R34,999,999", 30000000m },
                    { 6, "R25,000,000 - R29,999,999", 25000000m },
                    { 5, "R20,000,000 - R24,999,999", 20000000m },
                    { 4, "R15,000,000 - R19,999,999", 15000000m },
                    { 3, "R10,000,000 - R14,999,999", 10000000m },
                    { 2, "R5,000,000 - R9,999,999", 5000000m },
                    { 19, "R90,000,000 - R94,999,999", 90000000m },
                    { 20, "R95,000,000 - R100,000,000", 95000000m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceIntervals");
        }
    }
}
