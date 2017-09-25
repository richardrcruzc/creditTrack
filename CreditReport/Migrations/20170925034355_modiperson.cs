using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CreditReport.Migrations
{
    public partial class modiperson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Person_PersonID",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Inquiry");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_PersonID",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Ocupation",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Person",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "Person",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ocupation",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Passport",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Person",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Contacts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    PersonID = table.Column<int>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inquiry",
                columns: table => new
                {
                    InquiryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    InquiryType = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: true),
                    SubcriptorCompanyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiry", x => x.InquiryID);
                    table.ForeignKey(
                        name: "FK_Inquiry_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inquiry_Company_SubcriptorCompanyID",
                        column: x => x.SubcriptorCompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PersonID",
                table: "Contacts",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonID",
                table: "Address",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_PersonID",
                table: "Enrollment",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiry_PersonID",
                table: "Inquiry",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiry_SubcriptorCompanyID",
                table: "Inquiry",
                column: "SubcriptorCompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Person_PersonID",
                table: "Contacts",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
