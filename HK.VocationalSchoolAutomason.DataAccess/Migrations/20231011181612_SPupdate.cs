using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SPupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_HasParentInformation_Parent_Informations_ParentInformationId",
                table: "Student_HasParentInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_HasParentInformation_Students_StudentId",
                table: "Student_HasParentInformation");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Student_HasParentInformation",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "ParentInformationId",
                table: "Student_HasParentInformation",
                newName: "ParentInformationsId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_HasParentInformation_StudentId",
                table: "Student_HasParentInformation",
                newName: "IX_Student_HasParentInformation_StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_HasParentInformation_ParentInformationId",
                table: "Student_HasParentInformation",
                newName: "IX_Student_HasParentInformation_ParentInformationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_HasParentInformation_Parent_Informations_ParentInformationsId",
                table: "Student_HasParentInformation",
                column: "ParentInformationsId",
                principalTable: "Parent_Informations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_HasParentInformation_Students_StudentsId",
                table: "Student_HasParentInformation",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_HasParentInformation_Parent_Informations_ParentInformationsId",
                table: "Student_HasParentInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_HasParentInformation_Students_StudentsId",
                table: "Student_HasParentInformation");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "Student_HasParentInformation",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "ParentInformationsId",
                table: "Student_HasParentInformation",
                newName: "ParentInformationId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_HasParentInformation_StudentsId",
                table: "Student_HasParentInformation",
                newName: "IX_Student_HasParentInformation_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_HasParentInformation_ParentInformationsId",
                table: "Student_HasParentInformation",
                newName: "IX_Student_HasParentInformation_ParentInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_HasParentInformation_Parent_Informations_ParentInformationId",
                table: "Student_HasParentInformation",
                column: "ParentInformationId",
                principalTable: "Parent_Informations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_HasParentInformation_Students_StudentId",
                table: "Student_HasParentInformation",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
