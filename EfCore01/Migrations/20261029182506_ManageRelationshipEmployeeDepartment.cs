using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore01.Migrations
{
    /// <inheritdoc />
    public partial class ManageRelationshipEmployeeDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsTable_DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable",
                column: "DeptManagerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentsTable_EmployeesTable_DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable",
                column: "DeptManagerId",
                principalTable: "EmployeesTable",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentsTable_EmployeesTable_DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentsTable_DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable");

            migrationBuilder.DropColumn(
                name: "DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable");
        }
    }
}
