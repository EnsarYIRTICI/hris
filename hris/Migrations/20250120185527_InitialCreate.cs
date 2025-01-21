using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hris.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeePasswords_EmployeeId_IsActive",
                table: "EmployeePasswords");

            migrationBuilder.DropColumn(
                name: "PositionTemplateId",
                table: "EmployeePosition");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "EmployeePasswords",
                newName: "IsValid");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "EmployeeEmails",
                newName: "Email");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "EmployeeEmails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EmployeeEmails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "EmployeeEmails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePasswords_EmployeeId_IsValid",
                table: "EmployeePasswords",
                columns: new[] { "EmployeeId", "IsValid" },
                unique: true,
                filter: "[IsValid] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeePasswords_EmployeeId_IsValid",
                table: "EmployeePasswords");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "EmployeeEmails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeeEmails");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "EmployeeEmails");

            migrationBuilder.RenameColumn(
                name: "IsValid",
                table: "EmployeePasswords",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "EmployeeEmails",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "PositionTemplateId",
                table: "EmployeePosition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePasswords_EmployeeId_IsActive",
                table: "EmployeePasswords",
                columns: new[] { "EmployeeId", "IsActive" },
                unique: true,
                filter: "[IsActive] = 1");
        }
    }
}
