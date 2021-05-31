using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.API.Migrations
{
    public partial class newly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromTime",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ToTime",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "Slot",
                table: "Book",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slot",
                table: "Book");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromTime",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ToTime",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
