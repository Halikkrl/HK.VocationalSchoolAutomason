using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SemesterRelashipRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Semesters_SemesterId",
                table: "ClassRooms");

            migrationBuilder.DropIndex(
                name: "IX_ClassRooms_CourseId_SemesterId_Name",
                table: "ClassRooms");

            migrationBuilder.DropIndex(
                name: "IX_ClassRooms_SemesterId",
                table: "ClassRooms");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "ClassRooms");

            migrationBuilder.CreateTable(
                name: "StudentMajorLevelGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    MajorLevelGroupId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false),
                    LevelGruopMojorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMajorLevelGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentMajorLevelGroup_LevelGruopMojors_LevelGruopMojorId",
                        column: x => x.LevelGruopMojorId,
                        principalTable: "LevelGruopMojors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMajorLevelGroup_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_CourseId_Name",
                table: "ClassRooms",
                columns: new[] { "CourseId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroup_LevelGruopMojorId",
                table: "StudentMajorLevelGroup",
                column: "LevelGruopMojorId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroup_StudentsId",
                table: "StudentMajorLevelGroup",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentMajorLevelGroup");

            migrationBuilder.DropIndex(
                name: "IX_ClassRooms_CourseId_Name",
                table: "ClassRooms");

            migrationBuilder.AddColumn<int>(
                name: "SemesterId",
                table: "ClassRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_CourseId_SemesterId_Name",
                table: "ClassRooms",
                columns: new[] { "CourseId", "SemesterId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_SemesterId",
                table: "ClassRooms",
                column: "SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Semesters_SemesterId",
                table: "ClassRooms",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
