using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AirPortWebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FlightDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeparturePoint = table.Column<string>(type: "text", nullable: true),
                    DestinationPoint = table.Column<string>(type: "text", nullable: true),
                    RaceNumber = table.Column<string>(type: "text", nullable: true),
                    PlaneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketNumber = table.Column<string>(type: "text", nullable: true),
                    SeatNumber = table.Column<string>(type: "text", nullable: true),
                    RaceId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "DeparturePoint", "DestinationPoint", "FlightDate", "PlaneNumber", "RaceNumber" },
                values: new object[,]
                {
                    { 1, "Warsaw", "London", new DateTime(2023, 1, 1, 17, 15, 0, 0, DateTimeKind.Unspecified), "28f", "777A" },
                    { 2, "Warsaw", "Bucharest", new DateTime(2023, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), "28f", "777A" },
                    { 3, "Warsaw", "Bucharest", new DateTime(2023, 1, 1, 20, 15, 0, 0, DateTimeKind.Unspecified), "28f", "777A" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "PhoneNumber", "UserName" },
                values: new object[] { 2, "bossofthisgym@gmail.com", "aniki", null, "Billy Herringthon" });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "Id", "RaceId", "SeatNumber", "TicketNumber", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "15", "111", null },
                    { 3, 1, "9", "114", null },
                    { 4, 1, "18", "121", null },
                    { 2, 2, "28", "112", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RaceId",
                table: "Ticket",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
