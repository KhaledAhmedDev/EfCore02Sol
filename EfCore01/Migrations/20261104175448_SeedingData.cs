using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfCore01.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Sales",
                table: "DepartmentsTable",
                columns: new[] { "DeptId", "DeptManagerId", "DepartmentName" },
                values: new object[,]
                {
                    { 30, null, "Sales" },
                    { 40, null, "Marketing" },
                    { 50, null, "Finance" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "DepartmentsTable",
                keyColumn: "DeptId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "DepartmentsTable",
                keyColumn: "DeptId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "Sales",
                table: "DepartmentsTable",
                keyColumn: "DeptId",
                keyValue: 50);
        }
    }
}
