using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class StudentMajorLevelGroupSemesterTableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentMajorLevelGroup_LevelGruopMojors_LevelGruopMojorId",
                table: "StudentMajorLevelGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentMajorLevelGroup_Students_StudentsId",
                table: "StudentMajorLevelGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentMajorLevelGroup",
                table: "StudentMajorLevelGroup");

            migrationBuilder.DropIndex(
                name: "IX_StudentMajorLevelGroup_LevelGruopMojorId",
                table: "StudentMajorLevelGroup");

            migrationBuilder.DropColumn(
                name: "LevelGruopMojorId",
                table: "StudentMajorLevelGroup");

            migrationBuilder.RenameTable(
                name: "StudentMajorLevelGroup",
                newName: "StudentMajorLevelGroups");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "StudentMajorLevelGroups",
                newName: "SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentMajorLevelGroup_StudentsId",
                table: "StudentMajorLevelGroups",
                newName: "IX_StudentMajorLevelGroups_SemesterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentMajorLevelGroups",
                table: "StudentMajorLevelGroups",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroups_MajorLevelGroupId",
                table: "StudentMajorLevelGroups",
                column: "MajorLevelGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroups_StudentId",
                table: "StudentMajorLevelGroups",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMajorLevelGroups_LevelGruopMojors_MajorLevelGroupId",
                table: "StudentMajorLevelGroups",
                column: "MajorLevelGroupId",
                principalTable: "LevelGruopMojors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMajorLevelGroups_Semesters_SemesterId",
                table: "StudentMajorLevelGroups",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMajorLevelGroups_Students_StudentId",
                table: "StudentMajorLevelGroups",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentMajorLevelGroups_LevelGruopMojors_MajorLevelGroupId",
                table: "StudentMajorLevelGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentMajorLevelGroups_Semesters_SemesterId",
                table: "StudentMajorLevelGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentMajorLevelGroups_Students_StudentId",
                table: "StudentMajorLevelGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentMajorLevelGroups",
                table: "StudentMajorLevelGroups");

            migrationBuilder.DropIndex(
                name: "IX_StudentMajorLevelGroups_MajorLevelGroupId",
                table: "StudentMajorLevelGroups");

            migrationBuilder.DropIndex(
                name: "IX_StudentMajorLevelGroups_StudentId",
                table: "StudentMajorLevelGroups");

            migrationBuilder.RenameTable(
                name: "StudentMajorLevelGroups",
                newName: "StudentMajorLevelGroup");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "StudentMajorLevelGroup",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentMajorLevelGroups_SemesterId",
                table: "StudentMajorLevelGroup",
                newName: "IX_StudentMajorLevelGroup_StudentsId");

            migrationBuilder.AddColumn<int>(
                name: "LevelGruopMojorId",
                table: "StudentMajorLevelGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentMajorLevelGroup",
                table: "StudentMajorLevelGroup",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajorLevelGroup_LevelGruopMojorId",
                table: "StudentMajorLevelGroup",
                column: "LevelGruopMojorId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMajorLevelGroup_LevelGruopMojors_LevelGruopMojorId",
                table: "StudentMajorLevelGroup",
                column: "LevelGruopMojorId",
                principalTable: "LevelGruopMojors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMajorLevelGroup_Students_StudentsId",
                table: "StudentMajorLevelGroup",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
