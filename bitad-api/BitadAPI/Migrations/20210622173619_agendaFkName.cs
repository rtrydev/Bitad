using Microsoft.EntityFrameworkCore.Migrations;

namespace BitadAPI.Migrations
{
    public partial class agendaFkName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Speakers_SpeakerId",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "SpeakerId",
                table: "Agendas",
                newName: "speaker_id");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_SpeakerId",
                table: "Agendas",
                newName: "IX_Agendas_speaker_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Speakers_speaker_id",
                table: "Agendas",
                column: "speaker_id",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Speakers_speaker_id",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "speaker_id",
                table: "Agendas",
                newName: "SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_speaker_id",
                table: "Agendas",
                newName: "IX_Agendas_SpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Speakers_SpeakerId",
                table: "Agendas",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
