using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class StudentHasParentIdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Student_HasParentInformation",
                table: "Student_HasParentInformation");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Student_HasParentInformation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student_HasParentInformation",
                table: "Student_HasParentInformation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_HasParentInformation_StudentId",
                table: "Student_HasParentInformation",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Student_HasParentInformation",
                table: "Student_HasParentInformation");

            migrationBuilder.DropIndex(
                name: "IX_Student_HasParentInformation_StudentId",
                table: "Student_HasParentInformation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Student_HasParentInformation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student_HasParentInformation",
                table: "Student_HasParentInformation",
                columns: new[] { "StudentId", "ParentInformationId" });
        }
    }
}
