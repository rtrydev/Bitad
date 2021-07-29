using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class userChecks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivationCode",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivationDate",
                table: "users",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AttendanceCheckDate",
                table: "users",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttendanceCode",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmCode",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmDate",
                table: "users",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivationCode",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ActivationDate",
                table: "users");

            migrationBuilder.DropColumn(
                name: "AttendanceCheckDate",
                table: "users");

            migrationBuilder.DropColumn(
                name: "AttendanceCode",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ConfirmCode",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ConfirmDate",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "users");
        }
    }
}
