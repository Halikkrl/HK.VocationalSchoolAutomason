using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class StudentMajorLevelGroupTableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentMajorLevelGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentMajorLevelId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMajorLevelGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentMajorLevelGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMajorLevelGroups_StudentMajorLevels_StudentMajorLevelId",
                        column: x => x.StudentMajorLevelId,
                        principalTable: "StudentMajorLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroups_GroupId",
                table: "StudentMajorLevelGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroups_StudentMajorLevelId",
                table: "StudentMajorLevelGroups",
                column: "StudentMajorLevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentMajorLevelGroups");
        }
    }
}
