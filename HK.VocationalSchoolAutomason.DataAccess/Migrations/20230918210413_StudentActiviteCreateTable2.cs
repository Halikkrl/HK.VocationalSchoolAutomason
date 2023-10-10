using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class StudentActiviteCreateTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentActivities_Activities_ActivitiesId",
                table: "StudentActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentActivities_Students_StudentsId",
                table: "StudentActivities");

            migrationBuilder.DropIndex(
                name: "IX_StudentActivities_ActivitiesId",
                table: "StudentActivities");

            migrationBuilder.DropIndex(
                name: "IX_StudentActivities_StudentsId",
                table: "StudentActivities");

            migrationBuilder.DropColumn(
                name: "ActivitiesId",
                table: "StudentActivities");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "StudentActivities");

            migrationBuilder.CreateIndex(
                name: "IX_StudentActivities_ActiviteId",
                table: "StudentActivities",
                column: "ActiviteId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentActivities_StudentId",
                table: "StudentActivities",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentActivities_Activities_ActiviteId",
                table: "StudentActivities",
                column: "ActiviteId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentActivities_Students_StudentId",
                table: "StudentActivities",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentActivities_Activities_ActiviteId",
                table: "StudentActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentActivities_Students_StudentId",
                table: "StudentActivities");

            migrationBuilder.DropIndex(
                name: "IX_StudentActivities_ActiviteId",
                table: "StudentActivities");

            migrationBuilder.DropIndex(
                name: "IX_StudentActivities_StudentId",
                table: "StudentActivities");

            migrationBuilder.AddColumn<int>(
                name: "ActivitiesId",
                table: "StudentActivities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "StudentActivities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentActivities_ActivitiesId",
                table: "StudentActivities",
                column: "ActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentActivities_StudentsId",
                table: "StudentActivities",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentActivities_Activities_ActivitiesId",
                table: "StudentActivities",
                column: "ActivitiesId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentActivities_Students_StudentsId",
                table: "StudentActivities",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
