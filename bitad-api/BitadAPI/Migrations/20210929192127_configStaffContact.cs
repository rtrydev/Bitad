using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class configStaffContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "staff",
                newName: "contact");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "contact",
                table: "staff",
                newName: "Contact");
        }
    }
}
