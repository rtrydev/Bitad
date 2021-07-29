using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class userConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "users",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "ConfirmDate",
                table: "users",
                newName: "confirm_date");

            migrationBuilder.RenameColumn(
                name: "ConfirmCode",
                table: "users",
                newName: "confirm_code");

            migrationBuilder.RenameColumn(
                name: "AttendanceCode",
                table: "users",
                newName: "attendance_code");

            migrationBuilder.RenameColumn(
                name: "AttendanceCheckDate",
                table: "users",
                newName: "attendance_check_date");

            migrationBuilder.RenameColumn(
                name: "ActivationDate",
                table: "users",
                newName: "activation_date");

            migrationBuilder.RenameColumn(
                name: "ActivationCode",
                table: "users",
                newName: "activation_code");

            migrationBuilder.AlterColumn<int>(
                name: "role",
                table: "users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "confirm_date",
                table: "users",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "confirm_code",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "attendance_code",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "attendance_check_date",
                table: "users",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "activation_date",
                table: "users",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "activation_code",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "confirm_date",
                table: "users",
                newName: "ConfirmDate");

            migrationBuilder.RenameColumn(
                name: "confirm_code",
                table: "users",
                newName: "ConfirmCode");

            migrationBuilder.RenameColumn(
                name: "attendance_code",
                table: "users",
                newName: "AttendanceCode");

            migrationBuilder.RenameColumn(
                name: "attendance_check_date",
                table: "users",
                newName: "AttendanceCheckDate");

            migrationBuilder.RenameColumn(
                name: "activation_date",
                table: "users",
                newName: "ActivationDate");

            migrationBuilder.RenameColumn(
                name: "activation_code",
                table: "users",
                newName: "ActivationCode");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ConfirmDate",
                table: "users",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmCode",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AttendanceCode",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendanceCheckDate",
                table: "users",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActivationDate",
                table: "users",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ActivationCode",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
