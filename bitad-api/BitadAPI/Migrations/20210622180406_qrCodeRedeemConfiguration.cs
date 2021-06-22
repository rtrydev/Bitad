using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BitadAPI.Migrations
{
    public partial class qrCodeRedeemConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrCodeRedeems_qr_codes_QrCodeId",
                table: "QrCodeRedeems");

            migrationBuilder.DropForeignKey(
                name: "FK_QrCodeRedeems_Users_UserId",
                table: "QrCodeRedeems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QrCodeRedeems",
                table: "QrCodeRedeems");

            migrationBuilder.DropIndex(
                name: "IX_QrCodeRedeems_QrCodeId",
                table: "QrCodeRedeems");

            migrationBuilder.DropIndex(
                name: "IX_QrCodeRedeems_UserId",
                table: "QrCodeRedeems");

            migrationBuilder.DropColumn(
                name: "QrCodeId",
                table: "QrCodeRedeems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "QrCodeRedeems");

            migrationBuilder.RenameTable(
                name: "QrCodeRedeems",
                newName: "qr_code_reedeems");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "qr_codes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "qr_code_reedeems",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RedeemTime",
                table: "qr_code_reedeems",
                newName: "redeem_time");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "qr_codes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "qr_code_reedeems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "redeem_time",
                table: "qr_code_reedeems",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                name: "qr_code_id",
                table: "qr_code_reedeems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "qr_code_reedeems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_qr_code_reedeems",
                table: "qr_code_reedeems",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_qr_code_reedeems_qr_code_id",
                table: "qr_code_reedeems",
                column: "qr_code_id");

            migrationBuilder.CreateIndex(
                name: "IX_qr_code_reedeems_user_id",
                table: "qr_code_reedeems",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_qr_code_reedeems_qr_codes_qr_code_id",
                table: "qr_code_reedeems",
                column: "qr_code_id",
                principalTable: "qr_codes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_qr_code_reedeems_Users_user_id",
                table: "qr_code_reedeems",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_qr_code_reedeems_qr_codes_qr_code_id",
                table: "qr_code_reedeems");

            migrationBuilder.DropForeignKey(
                name: "FK_qr_code_reedeems_Users_user_id",
                table: "qr_code_reedeems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_qr_code_reedeems",
                table: "qr_code_reedeems");

            migrationBuilder.DropIndex(
                name: "IX_qr_code_reedeems_qr_code_id",
                table: "qr_code_reedeems");

            migrationBuilder.DropIndex(
                name: "IX_qr_code_reedeems_user_id",
                table: "qr_code_reedeems");

            migrationBuilder.DropColumn(
                name: "qr_code_id",
                table: "qr_code_reedeems");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "qr_code_reedeems");

            migrationBuilder.RenameTable(
                name: "qr_code_reedeems",
                newName: "QrCodeRedeems");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "qr_codes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "QrCodeRedeems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "redeem_time",
                table: "QrCodeRedeems",
                newName: "RedeemTime");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "qr_codes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "QrCodeRedeems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RedeemTime",
                table: "QrCodeRedeems",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AddColumn<int>(
                name: "QrCodeId",
                table: "QrCodeRedeems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "QrCodeRedeems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QrCodeRedeems",
                table: "QrCodeRedeems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_QrCodeRedeems_QrCodeId",
                table: "QrCodeRedeems",
                column: "QrCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_QrCodeRedeems_UserId",
                table: "QrCodeRedeems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodeRedeems_qr_codes_QrCodeId",
                table: "QrCodeRedeems",
                column: "QrCodeId",
                principalTable: "qr_codes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodeRedeems_Users_UserId",
                table: "QrCodeRedeems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
