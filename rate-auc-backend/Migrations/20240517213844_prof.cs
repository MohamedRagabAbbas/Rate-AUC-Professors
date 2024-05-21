using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateAucProfessors.Migrations
{
    /// <inheritdoc />
    public partial class prof : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Professors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Professors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Professors");
        }
    }
}
