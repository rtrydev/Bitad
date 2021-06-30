using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class configurationAgendaWorkshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "End",
                table: "workshops",
                newName: "end");

            migrationBuilder.RenameColumn(
                name: "Room",
                table: "agendas",
                newName: "room");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end",
                table: "workshops",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "end",
                table: "workshops",
                newName: "End");

            migrationBuilder.RenameColumn(
                name: "room",
                table: "agendas",
                newName: "Room");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "workshops",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");
        }
    }
}
