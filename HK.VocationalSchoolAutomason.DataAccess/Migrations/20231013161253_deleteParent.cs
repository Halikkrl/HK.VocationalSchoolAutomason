using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class deleteParent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_HasParentInformation");

            migrationBuilder.DropTable(
                name: "Parent_Informations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parent_Informations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PArentPhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    ParentDateOfIssue = table.Column<DateTime>(type: "datetime", nullable: false),
                    ParentFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentIdentificationNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ParentLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Proximity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent_Informations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student_HasParentInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentInformationsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_HasParentInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_HasParentInformation_Parent_Informations_ParentInformationsId",
                        column: x => x.ParentInformationsId,
                        principalTable: "Parent_Informations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_HasParentInformation_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Informations_Id",
                table: "Parent_Informations",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Informations_ParentIdentificationNumber",
                table: "Parent_Informations",
                column: "ParentIdentificationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_HasParentInformation_ParentInformationsId",
                table: "Student_HasParentInformation",
                column: "ParentInformationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_HasParentInformation_StudentsId",
                table: "Student_HasParentInformation",
                column: "StudentsId");
        }
    }
}
