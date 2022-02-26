using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem.Migrations
{
    public partial class finalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "Leaves",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Days",
                table: "Leaves");
        }
    }
}
