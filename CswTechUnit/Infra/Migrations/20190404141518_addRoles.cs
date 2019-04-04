using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class addRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Platoons_PlatoonId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Platoons",
                table: "Platoons");

            migrationBuilder.RenameTable(
                name: "Platoons",
                newName: "Platoon");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Employees",
                newName: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Platoon",
                table: "Platoon",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "JE" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "PE" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "SE" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Platoon_PlatoonId",
                table: "Employees",
                column: "PlatoonId",
                principalTable: "Platoon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Role_RoleId",
                table: "Employees",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Platoon_PlatoonId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Role_RoleId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RoleId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Platoon",
                table: "Platoon");

            migrationBuilder.RenameTable(
                name: "Platoon",
                newName: "Platoons");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Employees",
                newName: "Role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Platoons",
                table: "Platoons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Platoons_PlatoonId",
                table: "Employees",
                column: "PlatoonId",
                principalTable: "Platoons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
