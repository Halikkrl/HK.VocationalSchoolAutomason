using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class parentupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Parent_Informations",
                newName: "PArentPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Parent_Informations",
                newName: "ParentLastName");

            migrationBuilder.RenameColumn(
                name: "IdentificationNumber",
                table: "Parent_Informations",
                newName: "ParentIdentificationNumber");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Parent_Informations",
                newName: "ParentFirstName");

            migrationBuilder.RenameColumn(
                name: "DateOfIssue",
                table: "Parent_Informations",
                newName: "ParentDateOfIssue");

            migrationBuilder.RenameIndex(
                name: "IX_Parent_Informations_IdentificationNumber",
                table: "Parent_Informations",
                newName: "IX_Parent_Informations_ParentIdentificationNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentLastName",
                table: "Parent_Informations",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "ParentIdentificationNumber",
                table: "Parent_Informations",
                newName: "IdentificationNumber");

            migrationBuilder.RenameColumn(
                name: "ParentFirstName",
                table: "Parent_Informations",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "ParentDateOfIssue",
                table: "Parent_Informations",
                newName: "DateOfIssue");

            migrationBuilder.RenameColumn(
                name: "PArentPhoneNumber",
                table: "Parent_Informations",
                newName: "PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Parent_Informations_ParentIdentificationNumber",
                table: "Parent_Informations",
                newName: "IX_Parent_Informations_IdentificationNumber");
        }
    }
}
