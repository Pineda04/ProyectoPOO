using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoViajes.API.Migrations
{
    /// <inheritdoc />
    public partial class FixedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "agency",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    contact = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    registration_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agency", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "destination",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_destination", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "point_interest",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    destination_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_point_interest", x => x.id);
                    table.ForeignKey(
                        name: "FK_point_interest_destination_destination_id",
                        column: x => x.destination_id,
                        principalSchema: "dbo",
                        principalTable: "destination",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "travel_package",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    agency_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    destination_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travel_package", x => x.id);
                    table.ForeignKey(
                        name: "FK_travel_package_agency_agency_id",
                        column: x => x.agency_id,
                        principalSchema: "dbo",
                        principalTable: "agency",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_travel_package_destination_destination_id",
                        column: x => x.destination_id,
                        principalSchema: "dbo",
                        principalTable: "destination",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "activity",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    travel_package_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity", x => x.id);
                    table.ForeignKey(
                        name: "FK_activity_travel_package_travel_package_id",
                        column: x => x.travel_package_id,
                        principalSchema: "dbo",
                        principalTable: "travel_package",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assessments",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    package_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    rating_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessments", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessments_travel_package_package_id",
                        column: x => x.package_id,
                        principalSchema: "dbo",
                        principalTable: "travel_package",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    package_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reservation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_paid = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservations_travel_package_package_id",
                        column: x => x.package_id,
                        principalSchema: "dbo",
                        principalTable: "travel_package",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                schema: "dbo",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_payments_reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalSchema: "dbo",
                        principalTable: "reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activity_travel_package_id",
                schema: "dbo",
                table: "activity",
                column: "travel_package_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessments_package_id",
                schema: "dbo",
                table: "assessments",
                column: "package_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_ReservationId",
                schema: "dbo",
                table: "payments",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_point_interest_destination_id",
                schema: "dbo",
                table: "point_interest",
                column: "destination_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_package_id",
                schema: "dbo",
                table: "reservations",
                column: "package_id");

            migrationBuilder.CreateIndex(
                name: "IX_travel_package_agency_id",
                schema: "dbo",
                table: "travel_package",
                column: "agency_id");

            migrationBuilder.CreateIndex(
                name: "IX_travel_package_destination_id",
                schema: "dbo",
                table: "travel_package",
                column: "destination_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "assessments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "payments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "point_interest",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "reservations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "travel_package",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agency",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "destination",
                schema: "dbo");
        }
    }
}
