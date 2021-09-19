using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class accentColorDegree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "degree",
                table: "staff",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "accent_color",
                table: "speakers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "degree",
                table: "staff");

            migrationBuilder.DropColumn(
                name: "accent_color",
                table: "speakers");
        }
    }
}
