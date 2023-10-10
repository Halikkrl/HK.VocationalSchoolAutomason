using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class StudentMAjorLevelUpdateHasIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentMajorLevels_StudentId",
                table: "StudentMajorLevels");

            migrationBuilder.DropIndex(
                name: "IX_StudentMajorLevelGroups_GroupId",
                table: "StudentMajorLevelGroups");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevels_StudentId_MajorId_LevelId",
                table: "StudentMajorLevels",
                columns: new[] { "StudentId", "MajorId", "LevelId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroups_GroupId_StudentMajorLevelId",
                table: "StudentMajorLevelGroups",
                columns: new[] { "GroupId", "StudentMajorLevelId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentMajorLevels_StudentId_MajorId_LevelId",
                table: "StudentMajorLevels");

            migrationBuilder.DropIndex(
                name: "IX_StudentMajorLevelGroups_GroupId_StudentMajorLevelId",
                table: "StudentMajorLevelGroups");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevels_StudentId",
                table: "StudentMajorLevels",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroups_GroupId",
                table: "StudentMajorLevelGroups",
                column: "GroupId");
        }
    }
}
