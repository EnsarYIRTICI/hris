using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hris.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "EmployeeDocuments");

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "EmployeeDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Metadata",
                table: "EmployeeDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Kimlik Fotokopisi" },
                    { 2, null, "Sağlık Raporu" },
                    { 3, null, "Adli Sicil Kaydı" },
                    { 4, null, "İkametgâh Belgesi" },
                    { 5, null, "Eğitim Sertifikası" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_DocumentTypeId",
                table: "EmployeeDocuments",
                column: "DocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDocuments_DocumentTypes_DocumentTypeId",
                table: "EmployeeDocuments",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDocuments_DocumentTypes_DocumentTypeId",
                table: "EmployeeDocuments");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDocuments_DocumentTypeId",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "Metadata",
                table: "EmployeeDocuments");

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "EmployeeDocuments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
