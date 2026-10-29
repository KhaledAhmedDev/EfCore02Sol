using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore01.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeHasAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeCity",
                table: "EmployeesTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeCountry",
                table: "EmployeesTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeStreet",
                table: "EmployeesTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeCity",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "EmployeeCountry",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "EmployeeStreet",
                table: "EmployeesTable");
        }
    }
}
