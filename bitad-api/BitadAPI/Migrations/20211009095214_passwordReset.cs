using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class passwordReset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "last_password_reset",
                table: "users",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password_reset_code",
                table: "users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "last_password_reset",
                table: "users");

            migrationBuilder.DropColumn(
                name: "password_reset_code",
                table: "users");
        }
    }
}
