using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hris.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeEmails_EmployeeId",
                table: "EmployeeEmails");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPasswordChange",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Tckn",
                table: "Employees",
                column: "Tckn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmails_Email",
                table: "EmployeeEmails",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmails_EmployeeId_IsValid",
                table: "EmployeeEmails",
                columns: new[] { "EmployeeId", "IsValid" },
                unique: true,
                filter: "[IsValid] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Tckn",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeEmails_Email",
                table: "EmployeeEmails");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeEmails_EmployeeId_IsValid",
                table: "EmployeeEmails");

            migrationBuilder.DropColumn(
                name: "LastPasswordChange",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmails_EmployeeId",
                table: "EmployeeEmails",
                column: "EmployeeId");
        }
    }
}
