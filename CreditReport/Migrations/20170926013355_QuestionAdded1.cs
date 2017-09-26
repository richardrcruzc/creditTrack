using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditReport.Migrations
{
    public partial class QuestionAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Question",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherQuestionQuestionID",
                table: "Question",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_MotherQuestionQuestionID",
                table: "Question",
                column: "MotherQuestionQuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Question_MotherQuestionQuestionID",
                table: "Question",
                column: "MotherQuestionQuestionID",
                principalTable: "Question",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Question_MotherQuestionQuestionID",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_MotherQuestionQuestionID",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "MotherQuestionQuestionID",
                table: "Question");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Question",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
