using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateAucProfessors.Migrations
{
    /// <inheritdoc />
    public partial class addRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // add role to the database Student
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('1', 'Student', 'STUDENT')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // drop role Student
            migrationBuilder.Sql("DELETE FROM AspNetRoles WHERE Id = '1'");

        }
    }
}
