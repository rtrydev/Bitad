using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class qrCodeConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrCodeRedeems_QrCodes_QrCodeId",
                table: "QrCodeRedeems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QrCodes",
                table: "QrCodes");

            migrationBuilder.RenameTable(
                name: "QrCodes",
                newName: "qr_codes");

            migrationBuilder.RenameColumn(
                name: "Points",
                table: "qr_codes",
                newName: "points");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "qr_codes",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "DeactivationTime",
                table: "qr_codes",
                newName: "deactivation_time");

            migrationBuilder.RenameColumn(
                name: "ActivationTime",
                table: "qr_codes",
                newName: "activation_time");

            migrationBuilder.AlterColumn<int>(
                name: "points",
                table: "qr_codes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "qr_codes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deactivation_time",
                table: "qr_codes",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "activation_time",
                table: "qr_codes",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_qr_codes",
                table: "qr_codes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodeRedeems_qr_codes_QrCodeId",
                table: "QrCodeRedeems",
                column: "QrCodeId",
                principalTable: "qr_codes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrCodeRedeems_qr_codes_QrCodeId",
                table: "QrCodeRedeems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_qr_codes",
                table: "qr_codes");

            migrationBuilder.RenameTable(
                name: "qr_codes",
                newName: "QrCodes");

            migrationBuilder.RenameColumn(
                name: "points",
                table: "QrCodes",
                newName: "Points");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "QrCodes",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "deactivation_time",
                table: "QrCodes",
                newName: "DeactivationTime");

            migrationBuilder.RenameColumn(
                name: "activation_time",
                table: "QrCodes",
                newName: "ActivationTime");

            migrationBuilder.AlterColumn<int>(
                name: "Points",
                table: "QrCodes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "QrCodes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeactivationTime",
                table: "QrCodes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActivationTime",
                table: "QrCodes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddPrimaryKey(
                name: "PK_QrCodes",
                table: "QrCodes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodeRedeems_QrCodes_QrCodeId",
                table: "QrCodeRedeems",
                column: "QrCodeId",
                principalTable: "QrCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
