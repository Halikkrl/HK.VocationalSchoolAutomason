using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStudentMajrTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentMajorLevelGroups");

            migrationBuilder.DropTable(
                name: "StudentMajorLevels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentMajorLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMajorLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentMajorLevels_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMajorLevels_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMajorLevels_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentMajorLevelGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    StudentMajorLevelId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_StudentMajorLevelGroups_GroupId_StudentMajorLevelId",
                table: "StudentMajorLevelGroups",
                columns: new[] { "GroupId", "StudentMajorLevelId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroups_StudentMajorLevelId",
                table: "StudentMajorLevelGroups",
                column: "StudentMajorLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevels_LevelId",
                table: "StudentMajorLevels",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevels_MajorId",
                table: "StudentMajorLevels",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevels_StudentId_MajorId_LevelId",
                table: "StudentMajorLevels",
                columns: new[] { "StudentId", "MajorId", "LevelId" },
                unique: true);
        }
    }
}
