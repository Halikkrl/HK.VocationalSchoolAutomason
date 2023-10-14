using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentMajorLevelGroups_Students_StudentId",
                table: "StudentMajorLevelGroups");

            migrationBuilder.DropIndex(
                name: "IX_StudentMajorLevelGroups_StudentId_MajorLevelGroupId_SemesterId",
                table: "StudentMajorLevelGroups");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentMajorLevelGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroups_StudentId_MajorLevelGroupId_SemesterId",
                table: "StudentMajorLevelGroups",
                columns: new[] { "StudentId", "MajorLevelGroupId", "SemesterId" },
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMajorLevelGroups_Students_StudentId",
                table: "StudentMajorLevelGroups",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentMajorLevelGroups_Students_StudentId",
                table: "StudentMajorLevelGroups");

            migrationBuilder.DropIndex(
                name: "IX_StudentMajorLevelGroups_StudentId_MajorLevelGroupId_SemesterId",
                table: "StudentMajorLevelGroups");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentMajorLevelGroups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroups_StudentId_MajorLevelGroupId_SemesterId",
                table: "StudentMajorLevelGroups",
                columns: new[] { "StudentId", "MajorLevelGroupId", "SemesterId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMajorLevelGroups_Students_StudentId",
                table: "StudentMajorLevelGroups",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
