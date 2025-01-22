using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hris.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePosition_Employees_EmployeeId",
                table: "EmployeePosition");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePosition_Position_PositionId",
                table: "EmployeePosition");

            migrationBuilder.DropForeignKey(
                name: "FK_Position_Department_DepartmentId",
                table: "Position");

            migrationBuilder.DropForeignKey(
                name: "FK_Salary_EmployeePosition_PositionId",
                table: "Salary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePosition",
                table: "EmployeePosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "EmployeePosition",
                newName: "EmployeePositions");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_Position_DepartmentId",
                table: "Positions",
                newName: "IX_Positions_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePosition_PositionId",
                table: "EmployeePositions",
                newName: "IX_EmployeePositions_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePosition_EmployeeId",
                table: "EmployeePositions",
                newName: "IX_EmployeePositions_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePositions",
                table: "EmployeePositions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "IT" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Yönetici" },
                    { 2, 1, "Software Developer" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePositions_Employees_EmployeeId",
                table: "EmployeePositions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePositions_Positions_PositionId",
                table: "EmployeePositions",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Departments_DepartmentId",
                table: "Positions",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_EmployeePositions_PositionId",
                table: "Salary",
                column: "PositionId",
                principalTable: "EmployeePositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePositions_Employees_EmployeeId",
                table: "EmployeePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePositions_Positions_PositionId",
                table: "EmployeePositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Departments_DepartmentId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Salary_EmployeePositions_PositionId",
                table: "Salary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePositions",
                table: "EmployeePositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.RenameTable(
                name: "EmployeePositions",
                newName: "EmployeePosition");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_DepartmentId",
                table: "Position",
                newName: "IX_Position_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePositions_PositionId",
                table: "EmployeePosition",
                newName: "IX_EmployeePosition_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePositions_EmployeeId",
                table: "EmployeePosition",
                newName: "IX_EmployeePosition_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePosition",
                table: "EmployeePosition",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePosition_Employees_EmployeeId",
                table: "EmployeePosition",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePosition_Position_PositionId",
                table: "EmployeePosition",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Position_Department_DepartmentId",
                table: "Position",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_EmployeePosition_PositionId",
                table: "Salary",
                column: "PositionId",
                principalTable: "EmployeePosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
