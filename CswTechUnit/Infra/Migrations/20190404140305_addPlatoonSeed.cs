using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class addPlatoonSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Platoons",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alchemists" },
                    { 2, "Borg" },
                    { 3, "DeliveryOffice" },
                    { 4, "Fusion" },
                    { 5, "Jedi" },
                    { 6, "Klingon" },
                    { 7, "Machimbombo" },
                    { 8, "Patinhas" },
                    { 9, "Rebels" },
                    { 10, "Skywalkers" },
                    { 11, "Spartans" },
                    { 12, "Species" },
                    { 13, "Typhoon" },
                    { 14, "Vision" },
                    { 15, "Vulcan" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Platoons",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
