using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PassIn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToCheckInsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CheckIns_Attendee_Id",
                table: "CheckIns",
                column: "Attendee_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIns_Attendees_Attendee_Id",
                table: "CheckIns",
                column: "Attendee_Id",
                principalTable: "Attendees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckIns_Attendees_Attendee_Id",
                table: "CheckIns");

            migrationBuilder.DropIndex(
                name: "IX_CheckIns_Attendee_Id",
                table: "CheckIns");
        }
    }
}