using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStack.Data.Migrations
{
    public partial class ProvinceCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Adverts");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Adverts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Adverts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Gauteng" },
                    { 2, "Free State" },
                    { 3, "Western Cape" },
                    { 4, "Kwazulu-Natal" },
                    { 5, "Limpopo" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "Johannesburg", 1 },
                    { 2, "Pretoria", 1 },
                    { 3, "Bloemfontein", 2 },
                    { 4, "Welkom", 2 },
                    { 5, "Cape Town", 3 },
                    { 6, "Stellenbosch", 3 },
                    { 7, "Durban", 4 },
                    { 8, "Petermaritzburg", 4 },
                    { 9, "Polokwane", 5 },
                    { 10, "Modimolle", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CityId", "ProvinceId" },
                values: new object[] { 3, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_CityId",
                table: "Adverts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_ProvinceId",
                table: "Adverts",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Cities_CityId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Provinces_ProvinceId",
                table: "Adverts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_CityId",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_ProvinceId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Adverts");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Province" },
                values: new object[] { "Bloemfontein", "Free State" });
        }
    }
}
