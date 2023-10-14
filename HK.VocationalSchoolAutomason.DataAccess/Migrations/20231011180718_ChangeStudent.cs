using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Students",
                newName: "StudentNumber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "StudentLastName");

            migrationBuilder.RenameColumn(
                name: "IdentificationNumber",
                table: "Students",
                newName: "StudentIdentificationNumber");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Students",
                newName: "StudentGender");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Students",
                newName: "StudentFirstName");

            migrationBuilder.RenameIndex(
                name: "IX_Students_Number",
                table: "Students",
                newName: "IX_Students_StudentNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Students_IdentificationNumber",
                table: "Students",
                newName: "IX_Students_StudentIdentificationNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentNumber",
                table: "Students",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "StudentLastName",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "StudentIdentificationNumber",
                table: "Students",
                newName: "IdentificationNumber");

            migrationBuilder.RenameColumn(
                name: "StudentGender",
                table: "Students",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "StudentFirstName",
                table: "Students",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StudentNumber",
                table: "Students",
                newName: "IX_Students_Number");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StudentIdentificationNumber",
                table: "Students",
                newName: "IX_Students_IdentificationNumber");
        }
    }
}
