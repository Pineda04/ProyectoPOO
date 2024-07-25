using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoViajes.API.Migrations
{
    /// <inheritdoc />
    public partial class InitCreatetercer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_payments_ReservationId",
                schema: "dbo",
                table: "payments",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_payments_reservations_ReservationId",
                schema: "dbo",
                table: "payments",
                column: "ReservationId",
                principalSchema: "dbo",
                principalTable: "reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payments_reservations_ReservationId",
                schema: "dbo",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_ReservationId",
                schema: "dbo",
                table: "payments");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "reservations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
