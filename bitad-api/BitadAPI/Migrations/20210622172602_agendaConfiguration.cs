using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class agendaConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Agendas",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Agendas",
                newName: "start");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Agendas",
                newName: "end");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Agendas",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Agendas",
                newName: "created_at");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "Agendas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "start",
                table: "Agendas",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end",
                table: "Agendas",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Agendas",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Agendas",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Agendas",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "agenda",
                table: "Agendas",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "agenda",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Agendas",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "start",
                table: "Agendas",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "end",
                table: "Agendas",
                newName: "End");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Agendas",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Agendas",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Agendas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Agendas",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Agendas",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Agendas",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Agendas",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas",
                column: "id");
        }
    }
}
