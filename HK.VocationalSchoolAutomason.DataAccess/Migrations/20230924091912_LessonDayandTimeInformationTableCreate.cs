using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LessonDayandTimeInformationTableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LessonDayandTimeInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayId = table.Column<int>(type: "int", nullable: false),
                    WeekLessonHourId = table.Column<int>(type: "int", nullable: false),
                    WeeklyLessonHoursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonDayandTimeInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonDayandTimeInformation_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonDayandTimeInformation_WeeklyLessonHours_WeeklyLessonHoursId",
                        column: x => x.WeeklyLessonHoursId,
                        principalTable: "WeeklyLessonHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonDayandTimeInformation_DayId",
                table: "LessonDayandTimeInformation",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonDayandTimeInformation_WeeklyLessonHoursId",
                table: "LessonDayandTimeInformation",
                column: "WeeklyLessonHoursId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonDayandTimeInformation");
        }
    }
}
