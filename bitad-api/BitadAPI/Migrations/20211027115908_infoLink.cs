using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class infoLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "external_link",
                table: "workshops",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "short_info",
                table: "workshops",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "external_link",
                table: "workshops");

            migrationBuilder.DropColumn(
                name: "short_info",
                table: "workshops");
        }
    }
}
