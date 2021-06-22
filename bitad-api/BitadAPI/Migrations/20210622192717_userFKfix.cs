using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class userFKfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_workshops_workshop_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_workshop_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "workshop_id",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "workshop_id",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_workshop_id",
                table: "users",
                column: "workshop_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_workshops_workshop_id",
                table: "users",
                column: "workshop_id",
                principalTable: "workshops",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
