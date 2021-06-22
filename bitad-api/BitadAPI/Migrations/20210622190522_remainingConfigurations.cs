using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BitadAPI.Migrations
{
    public partial class remainingConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agendas_Speakers_speaker_id",
                table: "agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_qr_code_reedeems_Users_user_id",
                table: "qr_code_reedeems");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Workshops_WorkshopId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_Speakers_SpeakerId",
                table: "Workshops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workshops",
                table: "Workshops");

            migrationBuilder.DropIndex(
                name: "IX_Workshops_SpeakerId",
                table: "Workshops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sponsors",
                table: "Sponsors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "Workshops");

            migrationBuilder.RenameTable(
                name: "Workshops",
                newName: "workshops");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Sponsors",
                newName: "sponsors");

            migrationBuilder.RenameTable(
                name: "Speakers",
                newName: "speakers");

            migrationBuilder.RenameTable(
                name: "Staffs",
                newName: "staff");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "workshops",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "workshops",
                newName: "start");

            migrationBuilder.RenameColumn(
                name: "Room",
                table: "workshops",
                newName: "room");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "workshops",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "workshops",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "workshops",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MaxParticipants",
                table: "workshops",
                newName: "max_participants");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "users",
                newName: "password_salt");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "CurrentScore",
                table: "users",
                newName: "current_score");

            migrationBuilder.RenameColumn(
                name: "CurrentJwt",
                table: "users",
                newName: "current_jwt");

            migrationBuilder.RenameIndex(
                name: "IX_Users_WorkshopId",
                table: "users",
                newName: "IX_users_WorkshopId");

            migrationBuilder.RenameColumn(
                name: "Rank",
                table: "sponsors",
                newName: "rank");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "sponsors",
                newName: "picture");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "sponsors",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "sponsors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Webpage",
                table: "sponsors",
                newName: "website");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "speakers",
                newName: "website");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "speakers",
                newName: "picture");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "speakers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "speakers",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "speakers",
                newName: "company");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "speakers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WebsiteLink",
                table: "speakers",
                newName: "website_link");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "staff",
                newName: "picture");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "staff",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "staff",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "staff",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "workshops",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "start",
                table: "workshops",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "room",
                table: "workshops",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "workshops",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "workshops",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "workshops",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "max_participants",
                table: "workshops",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "speaker_id",
                table: "workshops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "WorkshopId",
                table: "users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "password_salt",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "current_score",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "workshop_id",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "rank",
                table: "sponsors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "sponsors",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "sponsors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "speakers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "speakers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "qr_code_reedeems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "speaker_id",
                table: "agendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "staff",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "staff",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_workshops",
                table: "workshops",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sponsors",
                table: "sponsors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_speakers",
                table: "speakers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_staff",
                table: "staff",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_workshops_speaker_id",
                table: "workshops",
                column: "speaker_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_workshop_id",
                table: "users",
                column: "workshop_id");

            migrationBuilder.AddForeignKey(
                name: "FK_agendas_speakers_speaker_id",
                table: "agendas",
                column: "speaker_id",
                principalTable: "speakers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_qr_code_reedeems_users_user_id",
                table: "qr_code_reedeems",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_workshops_workshop_id",
                table: "users",
                column: "workshop_id",
                principalTable: "workshops",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_workshops_WorkshopId",
                table: "users",
                column: "WorkshopId",
                principalTable: "workshops",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_workshops_speakers_speaker_id",
                table: "workshops",
                column: "speaker_id",
                principalTable: "speakers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agendas_speakers_speaker_id",
                table: "agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_qr_code_reedeems_users_user_id",
                table: "qr_code_reedeems");

            migrationBuilder.DropForeignKey(
                name: "FK_users_workshops_workshop_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_workshops_WorkshopId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_workshops_speakers_speaker_id",
                table: "workshops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workshops",
                table: "workshops");

            migrationBuilder.DropIndex(
                name: "IX_workshops_speaker_id",
                table: "workshops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_workshop_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sponsors",
                table: "sponsors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_speakers",
                table: "speakers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_staff",
                table: "staff");

            migrationBuilder.DropColumn(
                name: "speaker_id",
                table: "workshops");

            migrationBuilder.DropColumn(
                name: "workshop_id",
                table: "users");

            migrationBuilder.RenameTable(
                name: "workshops",
                newName: "Workshops");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "sponsors",
                newName: "Sponsors");

            migrationBuilder.RenameTable(
                name: "speakers",
                newName: "Speakers");

            migrationBuilder.RenameTable(
                name: "staff",
                newName: "Staffs");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Workshops",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "start",
                table: "Workshops",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "room",
                table: "Workshops",
                newName: "Room");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Workshops",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Workshops",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Workshops",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "max_participants",
                table: "Workshops",
                newName: "MaxParticipants");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "password_salt",
                table: "Users",
                newName: "PasswordSalt");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "current_score",
                table: "Users",
                newName: "CurrentScore");

            migrationBuilder.RenameColumn(
                name: "current_jwt",
                table: "Users",
                newName: "CurrentJwt");

            migrationBuilder.RenameIndex(
                name: "IX_users_WorkshopId",
                table: "Users",
                newName: "IX_Users_WorkshopId");

            migrationBuilder.RenameColumn(
                name: "rank",
                table: "Sponsors",
                newName: "Rank");

            migrationBuilder.RenameColumn(
                name: "picture",
                table: "Sponsors",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Sponsors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Sponsors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "website",
                table: "Sponsors",
                newName: "Webpage");

            migrationBuilder.RenameColumn(
                name: "website",
                table: "Speakers",
                newName: "Website");

            migrationBuilder.RenameColumn(
                name: "picture",
                table: "Speakers",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Speakers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Speakers",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "company",
                table: "Speakers",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Speakers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "website_link",
                table: "Speakers",
                newName: "WebsiteLink");

            migrationBuilder.RenameColumn(
                name: "picture",
                table: "Staffs",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Staffs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Staffs",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Staffs",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Workshops",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Workshops",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<string>(
                name: "Room",
                table: "Workshops",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Workshops",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Workshops",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Workshops",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "MaxParticipants",
                table: "Workshops",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SpeakerId",
                table: "Workshops",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "WorkshopId",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentScore",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Rank",
                table: "Sponsors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sponsors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Sponsors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Speakers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Speakers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "qr_code_reedeems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "speaker_id",
                table: "agendas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Staffs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Staffs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workshops",
                table: "Workshops",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sponsors",
                table: "Sponsors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Workshops_SpeakerId",
                table: "Workshops",
                column: "SpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_agendas_Speakers_speaker_id",
                table: "agendas",
                column: "speaker_id",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_qr_code_reedeems_Users_user_id",
                table: "qr_code_reedeems",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Workshops_WorkshopId",
                table: "Users",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_Speakers_SpeakerId",
                table: "Workshops",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
