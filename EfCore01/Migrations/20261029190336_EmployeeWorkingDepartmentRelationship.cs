using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore01.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeWorkingDepartmentRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentWorkingId",
                table: "EmployeesTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesTable_DepartmentWorkingId",
                table: "EmployeesTable",
                column: "DepartmentWorkingId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesTable_DepartmentsTable_DepartmentWorkingId",
                table: "EmployeesTable",
                column: "DepartmentWorkingId",
                principalSchema: "Sales",
                principalTable: "DepartmentsTable",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesTable_DepartmentsTable_DepartmentWorkingId",
                table: "EmployeesTable");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesTable_DepartmentWorkingId",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "DepartmentWorkingId",
                table: "EmployeesTable");
        }
    }
}
