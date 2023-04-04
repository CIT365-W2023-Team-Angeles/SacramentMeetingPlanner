using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class droppedSelection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selections_Hymns_HymnID",
                table: "Selections");

            migrationBuilder.DropForeignKey(
                name: "FK_Selections_Meetings_MeetingID",
                table: "Selections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Selections",
                table: "Selections");

            migrationBuilder.RenameTable(
                name: "Selections",
                newName: "Selection");

            migrationBuilder.RenameIndex(
                name: "IX_Selections_MeetingID",
                table: "Selection",
                newName: "IX_Selection_MeetingID");

            migrationBuilder.RenameIndex(
                name: "IX_Selections_HymnID",
                table: "Selection",
                newName: "IX_Selection_HymnID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Selection",
                table: "Selection",
                column: "SelectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Selection_Hymns_HymnID",
                table: "Selection",
                column: "HymnID",
                principalTable: "Hymns",
                principalColumn: "HymnID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Selection_Meetings_MeetingID",
                table: "Selection",
                column: "MeetingID",
                principalTable: "Meetings",
                principalColumn: "MeetingID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selection_Hymns_HymnID",
                table: "Selection");

            migrationBuilder.DropForeignKey(
                name: "FK_Selection_Meetings_MeetingID",
                table: "Selection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Selection",
                table: "Selection");

            migrationBuilder.RenameTable(
                name: "Selection",
                newName: "Selections");

            migrationBuilder.RenameIndex(
                name: "IX_Selection_MeetingID",
                table: "Selections",
                newName: "IX_Selections_MeetingID");

            migrationBuilder.RenameIndex(
                name: "IX_Selection_HymnID",
                table: "Selections",
                newName: "IX_Selections_HymnID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Selections",
                table: "Selections",
                column: "SelectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Selections_Hymns_HymnID",
                table: "Selections",
                column: "HymnID",
                principalTable: "Hymns",
                principalColumn: "HymnID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Selections_Meetings_MeetingID",
                table: "Selections",
                column: "MeetingID",
                principalTable: "Meetings",
                principalColumn: "MeetingID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
