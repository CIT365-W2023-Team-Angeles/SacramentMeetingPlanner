using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class speakers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeetingID",
                table: "Speakers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeakerID",
                table: "Meetings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_MeetingID",
                table: "Speakers",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_SpeakerID",
                table: "Meetings",
                column: "SpeakerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Speakers_SpeakerID",
                table: "Meetings",
                column: "SpeakerID",
                principalTable: "Speakers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Meetings_MeetingID",
                table: "Speakers",
                column: "MeetingID",
                principalTable: "Meetings",
                principalColumn: "MeetingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Speakers_SpeakerID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Meetings_MeetingID",
                table: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Speakers_MeetingID",
                table: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_SpeakerID",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "MeetingID",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "SpeakerID",
                table: "Meetings");
        }
    }
}
