using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AirPortWebAPI.Migrations
{
    public partial class CartFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Ticket",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PlaneNumber", "RaceNumber" },
                values: new object[] { "15b", "777B" });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PlaneNumber", "RaceNumber" },
                values: new object[] { "778a", "777C" });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CartId",
                table: "Ticket",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Carts_CartId",
                table: "Ticket",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Carts_CartId",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_CartId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Ticket");

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PlaneNumber", "RaceNumber" },
                values: new object[] { "28f", "777A" });

            migrationBuilder.UpdateData(
                table: "Races",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PlaneNumber", "RaceNumber" },
                values: new object[] { "28f", "777A" });
        }
    }
}
