using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PassIn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAttendeesToEventsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Attendees_Event_Id",
                table: "Attendees",
                column: "Event_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Events_Event_Id",
                table: "Attendees",
                column: "Event_Id",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Events_Event_Id",
                table: "Attendees");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_Event_Id",
                table: "Attendees");
        }
    }
}