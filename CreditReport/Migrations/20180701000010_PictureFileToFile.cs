using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditReport.Migrations
{
    public partial class PictureFileToFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Person_PersonID",
                table: "Picture");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Picture",
                newName: "CreditHistoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_PersonID",
                table: "Picture",
                newName: "IX_Picture_CreditHistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_CreditHistory_CreditHistoryID",
                table: "Picture",
                column: "CreditHistoryID",
                principalTable: "CreditHistory",
                principalColumn: "CreditHistoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_CreditHistory_CreditHistoryID",
                table: "Picture");

            migrationBuilder.RenameColumn(
                name: "CreditHistoryID",
                table: "Picture",
                newName: "PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_CreditHistoryID",
                table: "Picture",
                newName: "IX_Picture_PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Person_PersonID",
                table: "Picture",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
