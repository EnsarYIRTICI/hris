using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hris.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ShortCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "EmailTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tckn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastPasswordChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryStatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationshipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationshipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeBanks_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeBanks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDocuments_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDocuments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeEducations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEmails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeEmails_EmailTypes_EmailTypeId",
                        column: x => x.EmailTypeId,
                        principalTable: "EmailTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeEmails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePasswords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePasswords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePasswords_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    MaritalStatusTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMaritalStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeMaritalStatuses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeMaritalStatuses_MaritalStatusTypes_MaritalStatusTypeId",
                        column: x => x.MaritalStatusTypeId,
                        principalTable: "MaritalStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMilitaryStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    MilitaryStatusTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMilitaryStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeMilitaryStatuses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeMilitaryStatuses_MilitaryStatusTypes_MilitaryStatusTypeId",
                        column: x => x.MilitaryStatusTypeId,
                        principalTable: "MilitaryStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumberTypeId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePhoneNumbers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePhoneNumbers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePhoneNumbers_PhoneNumberTypes_PhoneNumberTypeId",
                        column: x => x.PhoneNumberTypeId,
                        principalTable: "PhoneNumberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRelatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RelationshipTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRelatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeRelatives_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRelatives_RelationshipTypes_RelationshipTypeId",
                        column: x => x.RelationshipTypeId,
                        principalTable: "RelationshipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAddresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAddresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeePositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salary_EmployeePositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "EmployeePositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Address", "Name", "SwiftCode" },
                values: new object[,]
                {
                    { 1, null, "Ziraat Bank", "TCZBTR2A" },
                    { 2, null, "Garanti BBVA", "TGBATRIS" },
                    { 3, null, "Akbank", "AKBKTRIS" },
                    { 4, null, "Yapı Kredi Bank", "YAPITRISFEX" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "PhoneCode", "ShortCode" },
                values: new object[,]
                {
                    { 1, "Turkey", "+90", "TR" },
                    { 2, "USA", "+1", "US" },
                    { 3, "Germany", "+49", "DE" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "IT" });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "ID Copy" },
                    { 2, null, "Health Report" },
                    { 3, null, "Criminal Record" },
                    { 4, null, "Proof of Residence" },
                    { 5, null, "Education Certificate" }
                });

            migrationBuilder.InsertData(
                table: "EmailTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Personal" },
                    { 2, "Work" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatusTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Married" },
                    { 2, "Single" },
                    { 3, "Widowed" }
                });

            migrationBuilder.InsertData(
                table: "MilitaryStatusTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Completed" },
                    { 2, "Deferred" },
                    { 3, "Exempt" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumberTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mobile" },
                    { 2, "Work" },
                    { 3, "Home" }
                });

            migrationBuilder.InsertData(
                table: "RelationshipTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mother" },
                    { 2, "Father" },
                    { 3, "Spouse" },
                    { 4, "Sibling" },
                    { 5, "Friend" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Manager" },
                    { 2, 1, "Software Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddresses_CityId",
                table: "EmployeeAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddresses_EmployeeId",
                table: "EmployeeAddresses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBanks_BankId",
                table: "EmployeeBanks",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBanks_EmployeeId",
                table: "EmployeeBanks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_DocumentTypeId",
                table: "EmployeeDocuments",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_EmployeeId",
                table: "EmployeeDocuments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducations_EmployeeId",
                table: "EmployeeEducations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmails_Email",
                table: "EmployeeEmails",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmails_EmailTypeId",
                table: "EmployeeEmails",
                column: "EmailTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmails_EmployeeId_IsValid",
                table: "EmployeeEmails",
                columns: new[] { "EmployeeId", "IsValid" },
                unique: true,
                filter: "[IsValid] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMaritalStatuses_EmployeeId",
                table: "EmployeeMaritalStatuses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMaritalStatuses_MaritalStatusTypeId",
                table: "EmployeeMaritalStatuses",
                column: "MaritalStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMilitaryStatuses_EmployeeId",
                table: "EmployeeMilitaryStatuses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMilitaryStatuses_MilitaryStatusTypeId",
                table: "EmployeeMilitaryStatuses",
                column: "MilitaryStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePasswords_EmployeeId_IsValid",
                table: "EmployeePasswords",
                columns: new[] { "EmployeeId", "IsValid" },
                unique: true,
                filter: "[IsValid] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhoneNumbers_CountryId",
                table: "EmployeePhoneNumbers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhoneNumbers_EmployeeId",
                table: "EmployeePhoneNumbers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhoneNumbers_PhoneNumberTypeId",
                table: "EmployeePhoneNumbers",
                column: "PhoneNumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_EmployeeId",
                table: "EmployeePositions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_PositionId",
                table: "EmployeePositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRelatives_EmployeeId",
                table: "EmployeeRelatives",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRelatives_RelationshipTypeId",
                table: "EmployeeRelatives",
                column: "RelationshipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Tckn",
                table: "Employees",
                column: "Tckn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_PositionId",
                table: "Salary",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAddresses");

            migrationBuilder.DropTable(
                name: "EmployeeBanks");

            migrationBuilder.DropTable(
                name: "EmployeeDocuments");

            migrationBuilder.DropTable(
                name: "EmployeeEducations");

            migrationBuilder.DropTable(
                name: "EmployeeEmails");

            migrationBuilder.DropTable(
                name: "EmployeeMaritalStatuses");

            migrationBuilder.DropTable(
                name: "EmployeeMilitaryStatuses");

            migrationBuilder.DropTable(
                name: "EmployeePasswords");

            migrationBuilder.DropTable(
                name: "EmployeePhoneNumbers");

            migrationBuilder.DropTable(
                name: "EmployeeRelatives");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "EmailTypes");

            migrationBuilder.DropTable(
                name: "MaritalStatusTypes");

            migrationBuilder.DropTable(
                name: "MilitaryStatusTypes");

            migrationBuilder.DropTable(
                name: "PhoneNumberTypes");

            migrationBuilder.DropTable(
                name: "RelationshipTypes");

            migrationBuilder.DropTable(
                name: "EmployeePositions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
