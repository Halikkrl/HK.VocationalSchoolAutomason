using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class WeekSemesterTableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SemesterWeek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    WeeksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterWeek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SemesterWeek_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemesterWeek_Weeks_WeeksId",
                        column: x => x.WeeksId,
                        principalTable: "Weeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SemesterWeek_SemesterId",
                table: "SemesterWeek",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterWeek_WeeksId",
                table: "SemesterWeek",
                column: "WeeksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SemesterWeek");
        }
    }
}
