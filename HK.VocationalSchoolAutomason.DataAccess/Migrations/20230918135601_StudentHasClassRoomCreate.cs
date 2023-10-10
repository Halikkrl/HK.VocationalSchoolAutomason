using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class StudentHasClassRoomCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassRooms",
                table: "ClassRooms");

            migrationBuilder.RenameTable(
                name: "ClassRooms",
                newName: "ClassRoom");

            migrationBuilder.RenameIndex(
                name: "IX_ClassRooms_Id",
                table: "ClassRoom",
                newName: "IX_ClassRoom_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassRoom",
                table: "ClassRoom",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StudentHasClassRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentHasClassRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentHasClassRoom_ClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentHasClassRoom_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentHasClassRoom_ClassRoomId",
                table: "StudentHasClassRoom",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHasClassRoom_StudentId",
                table: "StudentHasClassRoom",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentHasClassRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassRoom",
                table: "ClassRoom");

            migrationBuilder.RenameTable(
                name: "ClassRoom",
                newName: "ClassRooms");

            migrationBuilder.RenameIndex(
                name: "IX_ClassRoom_Id",
                table: "ClassRooms",
                newName: "IX_ClassRooms_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassRooms",
                table: "ClassRooms",
                column: "Id");
        }
    }
}
