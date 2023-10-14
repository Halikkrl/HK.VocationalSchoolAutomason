using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class namechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Levels",
                newName: "LevelName");

            migrationBuilder.RenameIndex(
                name: "IX_Levels_Name",
                table: "Levels",
                newName: "IX_Levels_LevelName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Groups",
                newName: "GroupName");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                newName: "IX_Groups_GroupName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LevelName",
                table: "Levels",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Levels_LevelName",
                table: "Levels",
                newName: "IX_Levels_Name");

            migrationBuilder.RenameColumn(
                name: "GroupName",
                table: "Groups",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_GroupName",
                table: "Groups",
                newName: "IX_Groups_Name");
        }
    }
}
