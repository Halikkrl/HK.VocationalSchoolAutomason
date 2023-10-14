using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class contactupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentContacts_Students_StudentId",
                table: "StudentContacts");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "StudentContacts");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentContacts",
                newName: "StudentPKId");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber2",
                table: "StudentContacts",
                newName: "ContactPhoneNumber2");

            migrationBuilder.RenameColumn(
                name: "DateOfIssue",
                table: "StudentContacts",
                newName: "ContactDateOfIssue");

            migrationBuilder.RenameIndex(
                name: "IX_StudentContacts_StudentId",
                table: "StudentContacts",
                newName: "IX_StudentContacts_StudentPKId");

            migrationBuilder.AddColumn<string>(
                name: "ContactPhoneNumber",
                table: "StudentContacts",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentContacts_Students_StudentPKId",
                table: "StudentContacts",
                column: "StudentPKId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentContacts_Students_StudentPKId",
                table: "StudentContacts");

            migrationBuilder.DropColumn(
                name: "ContactPhoneNumber",
                table: "StudentContacts");

            migrationBuilder.RenameColumn(
                name: "StudentPKId",
                table: "StudentContacts",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "ContactPhoneNumber2",
                table: "StudentContacts",
                newName: "PhoneNumber2");

            migrationBuilder.RenameColumn(
                name: "ContactDateOfIssue",
                table: "StudentContacts",
                newName: "DateOfIssue");

            migrationBuilder.RenameIndex(
                name: "IX_StudentContacts_StudentPKId",
                table: "StudentContacts",
                newName: "IX_StudentContacts_StudentId");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "StudentContacts",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentContacts_Students_StudentId",
                table: "StudentContacts",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
