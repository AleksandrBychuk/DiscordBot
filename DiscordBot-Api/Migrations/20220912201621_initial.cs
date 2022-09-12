using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscordBot_Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Text = table.Column<int>(type: "integer", nullable: false),
                    DateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
