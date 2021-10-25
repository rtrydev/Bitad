using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class userBan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "banned_from_roulette",
                table: "users",
                type: "bool",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "workshop_attendance_check_date",
                table: "users",
                type: "timestamp",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "banned_from_roulette",
                table: "users");

            migrationBuilder.DropColumn(
                name: "workshop_attendance_check_date",
                table: "users");
        }
    }
}
