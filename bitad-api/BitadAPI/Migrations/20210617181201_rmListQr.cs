using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class rmListQr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_QrCodes_QrCodeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_QrCodeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "QrCodeId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QrCodeId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_QrCodeId",
                table: "Users",
                column: "QrCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_QrCodes_QrCodeId",
                table: "Users",
                column: "QrCodeId",
                principalTable: "QrCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
