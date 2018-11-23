using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeartsTracker.Dal.Migrations
{
    public partial class AddedIsKeepRoundToGameRoundTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "GameRound");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "GameRound");

            migrationBuilder.AddColumn<bool>(
                name: "IsKeepRound",
                table: "GameRound",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsKeepRound",
                table: "GameRound");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "GameRound",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                table: "GameRound",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
