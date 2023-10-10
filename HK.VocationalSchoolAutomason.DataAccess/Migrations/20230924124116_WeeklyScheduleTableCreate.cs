using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class WeeklyScheduleTableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklySchedule_Semesters_SemesterId",
                table: "WeeklySchedule");

            migrationBuilder.AlterColumn<int>(
                name: "SemesterId",
                table: "WeeklySchedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ScheduleInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterWeeksId = table.Column<int>(type: "int", nullable: false),
                    WeeklyScheduleId = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    AbsentStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleInformations_SemesterWeek_SemesterWeeksId",
                        column: x => x.SemesterWeeksId,
                        principalTable: "SemesterWeek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleInformations_Students_AbsentStudentId",
                        column: x => x.AbsentStudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleInformations_WeeklySchedule_WeeklyScheduleId",
                        column: x => x.WeeklyScheduleId,
                        principalTable: "WeeklySchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleInformations_AbsentStudentId_SemesterWeeksId_WeeklyScheduleId",
                table: "ScheduleInformations",
                columns: new[] { "AbsentStudentId", "SemesterWeeksId", "WeeklyScheduleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleInformations_SemesterWeeksId",
                table: "ScheduleInformations",
                column: "SemesterWeeksId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleInformations_WeeklyScheduleId",
                table: "ScheduleInformations",
                column: "WeeklyScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklySchedule_Semesters_SemesterId",
                table: "WeeklySchedule",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklySchedule_Semesters_SemesterId",
                table: "WeeklySchedule");

            migrationBuilder.DropTable(
                name: "ScheduleInformations");

            migrationBuilder.AlterColumn<int>(
                name: "SemesterId",
                table: "WeeklySchedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklySchedule_Semesters_SemesterId",
                table: "WeeklySchedule",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
