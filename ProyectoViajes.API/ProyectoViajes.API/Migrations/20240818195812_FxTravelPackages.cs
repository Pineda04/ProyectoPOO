using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoViajes.API.Migrations
{
    /// <inheritdoc />
    public partial class FxTravelPackages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image_url",
                schema: "dbo",
                table: "travel_package",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_url",
                schema: "dbo",
                table: "travel_package");
        }
    }
}
