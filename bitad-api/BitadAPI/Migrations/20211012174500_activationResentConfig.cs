using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class activationResentConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivationCodeResent",
                table: "users",
                newName: "activation_code_resent");

            migrationBuilder.AlterColumn<DateTime>(
                name: "activation_code_resent",
                table: "users",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "activation_code_resent",
                table: "users",
                newName: "ActivationCodeResent");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActivationCodeResent",
                table: "users",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);
        }
    }
}
