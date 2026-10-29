using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore01.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeAndDepartmentAddFluentApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.CreateTable(
                name: "DepartmentsTable",
                schema: "Sales",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    DepartmentName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Serial = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsTable", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesTable",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    EmployeeName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesTable", x => x.EmpId);
                    table.CheckConstraint("CheckAgeConstraint", "Email like '%@%.%'");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentsTable",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "EmployeesTable");
        }
    }
}
