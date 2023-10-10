using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class WeeklyScheduleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeeklySchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassLessonsId = table.Column<int>(type: "int", nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false),
                    LessonDayandTimeInformationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklySchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklySchedule_ClassLessons_ClassLessonsId",
                        column: x => x.ClassLessonsId,
                        principalTable: "ClassLessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeeklySchedule_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeeklySchedule_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeeklySchedule_LessonDayandTimeInformation_LessonDayandTimeInformationId",
                        column: x => x.LessonDayandTimeInformationId,
                        principalTable: "LessonDayandTimeInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeeklySchedule_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedule_ClassLessonsId",
                table: "WeeklySchedule",
                column: "ClassLessonsId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedule_ClassRoomId",
                table: "WeeklySchedule",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedule_EmployeeId",
                table: "WeeklySchedule",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedule_LessonDayandTimeInformationId",
                table: "WeeklySchedule",
                column: "LessonDayandTimeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedule_SemesterId",
                table: "WeeklySchedule",
                column: "SemesterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklySchedule");
        }
    }
}
