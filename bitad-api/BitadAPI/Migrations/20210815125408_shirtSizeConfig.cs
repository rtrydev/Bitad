using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class shirtSizeConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShirtSize",
                table: "users",
                newName: "shirt_size");

            migrationBuilder.AlterColumn<int>(
                name: "shirt_size",
                table: "users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "shirt_size",
                table: "users",
                newName: "ShirtSize");

            migrationBuilder.AlterColumn<int>(
                name: "ShirtSize",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
