using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class staffContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "staff",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "staff");
        }
    }
}
