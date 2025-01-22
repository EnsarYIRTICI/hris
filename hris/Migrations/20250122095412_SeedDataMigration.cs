using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hris.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmployeeEmails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Ziraat Bank");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Yapı Kredi Bank");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Turkey");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "USA");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Germany");

            migrationBuilder.UpdateData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "ID Copy");

            migrationBuilder.UpdateData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Health Report");

            migrationBuilder.UpdateData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Criminal Record");

            migrationBuilder.UpdateData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Proof of Residence");

            migrationBuilder.UpdateData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Education Certificate");

            migrationBuilder.UpdateData(
                table: "MaritalStatusTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Married");

            migrationBuilder.UpdateData(
                table: "MaritalStatusTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Single");

            migrationBuilder.UpdateData(
                table: "MaritalStatusTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Widowed");

            migrationBuilder.UpdateData(
                table: "MilitaryStatusTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Completed");

            migrationBuilder.UpdateData(
                table: "MilitaryStatusTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Deferred");

            migrationBuilder.UpdateData(
                table: "MilitaryStatusTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Exempt");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Manager");

            migrationBuilder.UpdateData(
                table: "RelationshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Mother");

            migrationBuilder.UpdateData(
                table: "RelationshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Father");

            migrationBuilder.UpdateData(
                table: "RelationshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Spouse");

            migrationBuilder.UpdateData(
                table: "RelationshipTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Sibling");

            migrationBuilder.UpdateData(
                table: "RelationshipTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Friend");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmployeeEmails");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Ziraat Bankası");

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Yapı Kredi Bankası");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Türkiye");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "ABD");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Almanya");

            migrationBuilder.UpdateData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Kimlik Fotokopisi");

            migrationBuilder.UpdateData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Sağlık Raporu");

            migrationBuilder.UpdateData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Adli Sicil Kaydı");

            migrationBuilder.UpdateData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "İkametgâh Belgesi");

            migrationBuilder.UpdateData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Eğitim Sertifikası");

            migrationBuilder.UpdateData(
                table: "MaritalStatusTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Evli");

            migrationBuilder.UpdateData(
                table: "MaritalStatusTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Bekar");

            migrationBuilder.UpdateData(
                table: "MaritalStatusTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Dul");

            migrationBuilder.UpdateData(
                table: "MilitaryStatusTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Tamamlandı");

            migrationBuilder.UpdateData(
                table: "MilitaryStatusTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Tecilli");

            migrationBuilder.UpdateData(
                table: "MilitaryStatusTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Muaf");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Yönetici");

            migrationBuilder.UpdateData(
                table: "RelationshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Anne");

            migrationBuilder.UpdateData(
                table: "RelationshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Baba");

            migrationBuilder.UpdateData(
                table: "RelationshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Eş");

            migrationBuilder.UpdateData(
                table: "RelationshipTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Kardeş");

            migrationBuilder.UpdateData(
                table: "RelationshipTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Arkadaş");
        }
    }
}
