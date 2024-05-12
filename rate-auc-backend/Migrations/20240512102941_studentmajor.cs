using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateAucProfessors.Migrations
{
    /// <inheritdoc />
    public partial class studentmajor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentMajors");

            migrationBuilder.CreateTable(
                name: "StudentMajor",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMajor", x => new { x.StudentId, x.MajorId });
                    table.ForeignKey(
                        name: "FK_StudentMajor_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMajor_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajor_MajorId",
                table: "StudentMajor",
                column: "MajorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentMajor");

            migrationBuilder.CreateTable(
                name: "StudentMajors",
                columns: table => new
                {
                    MajorsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMajors", x => new { x.MajorsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_StudentMajors_AspNetUsers_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMajors_Majors_MajorsId",
                        column: x => x.MajorsId,
                        principalTable: "Majors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentMajors_StudentsId",
                table: "StudentMajors",
                column: "StudentsId");
        }
    }
}
