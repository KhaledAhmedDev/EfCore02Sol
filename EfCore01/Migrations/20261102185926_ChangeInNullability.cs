using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore01.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInNullability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DepartmentsTable_DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable");

            migrationBuilder.AlterColumn<int>(
                name: "DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsTable_DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable",
                column: "DeptManagerId",
                unique: true,
                filter: "[DeptManagerId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DepartmentsTable_DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable");

            migrationBuilder.AlterColumn<int>(
                name: "DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsTable_DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable",
                column: "DeptManagerId",
                unique: true);
        }
    }
}
