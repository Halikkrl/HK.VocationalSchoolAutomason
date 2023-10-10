using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class StudentHasClassRoomUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentHasClassRoom_StudentId",
                table: "StudentHasClassRoom");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHasClassRoom_StudentId_ClassRoomId",
                table: "StudentHasClassRoom",
                columns: new[] { "StudentId", "ClassRoomId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentHasClassRoom_StudentId_ClassRoomId",
                table: "StudentHasClassRoom");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHasClassRoom_StudentId",
                table: "StudentHasClassRoom",
                column: "StudentId");
        }
    }
}
