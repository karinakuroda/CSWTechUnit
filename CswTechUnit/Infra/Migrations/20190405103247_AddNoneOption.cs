using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class AddNoneOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Platoon",
                columns: new[] { "Id", "Name" },
                values: new object[] { 16, "None" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platoon",
                keyColumn: "Id",
                keyValue: 16);
        }
    }
}
