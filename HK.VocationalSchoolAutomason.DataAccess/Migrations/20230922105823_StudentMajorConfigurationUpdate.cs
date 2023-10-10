using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class StudentMajorConfigurationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentMajorLevelGroups_StudentId",
                table: "StudentMajorLevelGroups");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroups_StudentId_MajorLevelGroupId_SemesterId",
                table: "StudentMajorLevelGroups",
                columns: new[] { "StudentId", "MajorLevelGroupId", "SemesterId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentMajorLevelGroups_StudentId_MajorLevelGroupId_SemesterId",
                table: "StudentMajorLevelGroups");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroups_StudentId",
                table: "StudentMajorLevelGroups",
                column: "StudentId");
        }
    }
}
