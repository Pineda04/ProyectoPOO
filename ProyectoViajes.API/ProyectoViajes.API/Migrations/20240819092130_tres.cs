using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoViajes.API.Migrations
{
    /// <inheritdoc />
    public partial class tres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "registration_date",
                schema: "dbo",
                table: "user",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "registration_date",
                schema: "dbo",
                table: "user");
        }
    }
}
