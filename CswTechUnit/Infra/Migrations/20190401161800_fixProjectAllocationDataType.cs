using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class fixProjectAllocationDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PercentageAllocation",
                table: "ProjectAllocations",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PercentageAllocation",
                table: "ProjectAllocations",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
