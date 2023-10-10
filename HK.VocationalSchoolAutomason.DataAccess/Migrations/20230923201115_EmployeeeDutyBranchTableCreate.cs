using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeeDutyBranchTableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeDutyBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeDutyId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDutyBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDutyBranches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDutyBranches_EmployeeDuties_EmployeeDutyId",
                        column: x => x.EmployeeDutyId,
                        principalTable: "EmployeeDuties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDutyBranches_BranchId",
                table: "EmployeeDutyBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDutyBranches_EmployeeDutyId",
                table: "EmployeeDutyBranches",
                column: "EmployeeDutyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDutyBranches");
        }
    }
}
