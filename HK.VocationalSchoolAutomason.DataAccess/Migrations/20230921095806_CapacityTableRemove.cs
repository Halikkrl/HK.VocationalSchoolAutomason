using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CapacityTableRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Capacities_CapacityId",
                table: "ClassRooms");

            migrationBuilder.DropTable(
                name: "Capacities");

            migrationBuilder.DropIndex(
                name: "IX_ClassRooms_CapacityId",
                table: "ClassRooms");

            migrationBuilder.DropIndex(
                name: "IX_ClassRooms_CourseId_SemesterId_CapacityId_Name",
                table: "ClassRooms");

            migrationBuilder.DropColumn(
                name: "CapacityId",
                table: "ClassRooms");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_CourseId_SemesterId_Name",
                table: "ClassRooms",
                columns: new[] { "CourseId", "SemesterId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClassRooms_CourseId_SemesterId_Name",
                table: "ClassRooms");

            migrationBuilder.AddColumn<int>(
                name: "CapacityId",
                table: "ClassRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Capacities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_CapacityId",
                table: "ClassRooms",
                column: "CapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_CourseId_SemesterId_CapacityId_Name",
                table: "ClassRooms",
                columns: new[] { "CourseId", "SemesterId", "CapacityId", "Name" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Capacities_CapacityId",
                table: "ClassRooms",
                column: "CapacityId",
                principalTable: "Capacities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
