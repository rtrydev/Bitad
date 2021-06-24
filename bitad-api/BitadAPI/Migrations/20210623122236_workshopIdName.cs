using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class workshopIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_workshops_WorkshopId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "WorkshopId",
                table: "users",
                newName: "workshop_id");

            migrationBuilder.RenameIndex(
                name: "IX_users_WorkshopId",
                table: "users",
                newName: "IX_users_workshop_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_workshops_workshop_id",
                table: "users",
                column: "workshop_id",
                principalTable: "workshops",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_workshops_workshop_id",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "workshop_id",
                table: "users",
                newName: "WorkshopId");

            migrationBuilder.RenameIndex(
                name: "IX_users_workshop_id",
                table: "users",
                newName: "IX_users_WorkshopId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_workshops_WorkshopId",
                table: "users",
                column: "WorkshopId",
                principalTable: "workshops",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
