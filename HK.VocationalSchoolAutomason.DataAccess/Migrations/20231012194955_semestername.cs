using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class semestername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Semesters",
                newName: "SemesterName");

            migrationBuilder.RenameIndex(
                name: "IX_Semesters_Name",
                table: "Semesters",
                newName: "IX_Semesters_SemesterName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SemesterName",
                table: "Semesters",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Semesters_SemesterName",
                table: "Semesters",
                newName: "IX_Semesters_Name");
        }
    }
}
