using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class agendaTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Speakers_speaker_id",
                table: "Agendas");

            migrationBuilder.DropPrimaryKey(
                name: "agenda",
                table: "Agendas");

            migrationBuilder.RenameTable(
                name: "Agendas",
                newName: "agendas");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_speaker_id",
                table: "agendas",
                newName: "IX_agendas_speaker_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_agendas",
                table: "agendas",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_agendas_Speakers_speaker_id",
                table: "agendas",
                column: "speaker_id",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agendas_Speakers_speaker_id",
                table: "agendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_agendas",
                table: "agendas");

            migrationBuilder.RenameTable(
                name: "agendas",
                newName: "Agendas");

            migrationBuilder.RenameIndex(
                name: "IX_agendas_speaker_id",
                table: "Agendas",
                newName: "IX_Agendas_speaker_id");

            migrationBuilder.AddPrimaryKey(
                name: "agenda",
                table: "Agendas",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Speakers_speaker_id",
                table: "Agendas",
                column: "speaker_id",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
