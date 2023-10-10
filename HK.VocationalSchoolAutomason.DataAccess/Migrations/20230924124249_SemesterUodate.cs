using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SemesterUodate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklySchedule_Semesters_SemesterId",
                table: "WeeklySchedule");

            migrationBuilder.DropIndex(
                name: "IX_WeeklySchedule_SemesterId",
                table: "WeeklySchedule");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "WeeklySchedule");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SemesterId",
                table: "WeeklySchedule",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedule_SemesterId",
                table: "WeeklySchedule",
                column: "SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklySchedule_Semesters_SemesterId",
                table: "WeeklySchedule",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");
        }
    }
}
