using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BitadAPI.Migrations
{
    public partial class qrCodeRedeem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QrCodeId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QrCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Points = table.Column<int>(type: "integer", nullable: false),
                    ActivationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeactivationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QrCodeRedeems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QrCodeId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    RedeemTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCodeRedeems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QrCodeRedeems_QrCodes_QrCodeId",
                        column: x => x.QrCodeId,
                        principalTable: "QrCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QrCodeRedeems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_QrCodeId",
                table: "Users",
                column: "QrCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_QrCodeRedeems_QrCodeId",
                table: "QrCodeRedeems",
                column: "QrCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_QrCodeRedeems_UserId",
                table: "QrCodeRedeems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_QrCodes_QrCodeId",
                table: "Users",
                column: "QrCodeId",
                principalTable: "QrCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_QrCodes_QrCodeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "QrCodeRedeems");

            migrationBuilder.DropTable(
                name: "QrCodes");

            migrationBuilder.DropIndex(
                name: "IX_Users_QrCodeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "QrCodeId",
                table: "Users");
        }
    }
}
