using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateAucProfessors.Migrations
{
    /// <inheritdoc />
    public partial class addedColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "AspNetUsers");
        }
    }
}
