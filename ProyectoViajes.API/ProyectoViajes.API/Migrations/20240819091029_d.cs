using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoViajes.API.Migrations
{
    /// <inheritdoc />
    public partial class d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rol",
                schema: "dbo",
                table: "user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "rol",
                schema: "dbo",
                table: "user",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
