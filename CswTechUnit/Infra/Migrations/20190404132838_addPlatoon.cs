using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class addPlatoon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Platoon",
                table: "Employees",
                newName: "PlatoonId");

            migrationBuilder.CreateTable(
                name: "Platoons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platoons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PlatoonId",
                table: "Employees",
                column: "PlatoonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Platoons_PlatoonId",
                table: "Employees",
                column: "PlatoonId",
                principalTable: "Platoons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Platoons_PlatoonId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Platoons");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PlatoonId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PlatoonId",
                table: "Employees",
                newName: "Platoon");
        }
    }
}
