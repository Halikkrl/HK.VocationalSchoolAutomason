using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HK.VocationalSchoolAutomason.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTableSix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseBranches");

            migrationBuilder.DropTable(
                name: "EmployeeDutyBranches");

            migrationBuilder.DropTable(
                name: "WeeklySchedules");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "CourseLGMs");

            migrationBuilder.DropTable(
                name: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDutyBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    EmployeeDutyId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "CourseBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseBranches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseBranches_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseLGMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    LGMId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLGMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseLGMs_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseLGMs_LevelGruopMojors_LGMId",
                        column: x => x.LGMId,
                        principalTable: "LevelGruopMojors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeeklySchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseLGMId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklySchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklySchedules_CourseLGMs_CourseLGMId",
                        column: x => x.CourseLGMId,
                        principalTable: "CourseLGMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Name",
                table: "Branches",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseBranches_BranchId",
                table: "CourseBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseBranches_CourseId",
                table: "CourseBranches",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLGMs_CourseId",
                table: "CourseLGMs",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLGMs_LGMId",
                table: "CourseLGMs",
                column: "LGMId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Name",
                table: "Courses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDutyBranches_BranchId",
                table: "EmployeeDutyBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDutyBranches_EmployeeDutyId",
                table: "EmployeeDutyBranches",
                column: "EmployeeDutyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedules_CourseLGMId",
                table: "WeeklySchedules",
                column: "CourseLGMId");
        }
    }
}
