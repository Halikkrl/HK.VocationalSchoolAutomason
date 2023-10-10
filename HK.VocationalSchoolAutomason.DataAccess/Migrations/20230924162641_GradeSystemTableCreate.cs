using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class GradeSystemTableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GradeSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentMajorLevelGroupId = table.Column<int>(type: "int", nullable: false),
                    NoteOne = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    NoteTwo = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    NoteThree = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    OralGrade = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    Average = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeSystems_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradeSystems_StudentMajorLevelGroups_StudentMajorLevelGroupId",
                        column: x => x.StudentMajorLevelGroupId,
                        principalTable: "StudentMajorLevelGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradeSystems_CourseId",
                table: "GradeSystems",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeSystems_StudentMajorLevelGroupId",
                table: "GradeSystems",
                column: "StudentMajorLevelGroupId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradeSystems");
        }
    }
}
