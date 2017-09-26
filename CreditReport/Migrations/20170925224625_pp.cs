using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditReport.Migrations
{
    public partial class pp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "CreditHistory",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "CreditHistory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "CreditHistory");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "CreditHistory",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1500);
        }
    }
}
