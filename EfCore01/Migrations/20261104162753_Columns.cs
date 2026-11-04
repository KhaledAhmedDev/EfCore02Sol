using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore01.Migrations
{
    /// <inheritdoc />
    public partial class Columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serial",
                schema: "Sales",
                table: "DepartmentsTable");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "EmployeesTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "EmployeesTable",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "EmployeesTable");

            migrationBuilder.AddColumn<int>(
                name: "Serial",
                schema: "Sales",
                table: "DepartmentsTable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
