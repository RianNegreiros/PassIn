using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PassIn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateCheckInsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckIns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created_At = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Attendee_Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckIns", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckIns");
        }
    }
}