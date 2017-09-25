using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditReport.Migrations
{
    public partial class credit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditHistory_Company_CompanyID",
                table: "CreditHistory");

            migrationBuilder.DropIndex(
                name: "IX_CreditHistory_CompanyID",
                table: "CreditHistory");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "CreditHistory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "CreditHistory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditHistory_CompanyID",
                table: "CreditHistory",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditHistory_Company_CompanyID",
                table: "CreditHistory",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
