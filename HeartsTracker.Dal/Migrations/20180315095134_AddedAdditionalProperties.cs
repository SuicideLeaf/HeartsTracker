using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HeartsTracker.Dal.Migrations
{
    public partial class AddedAdditionalProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BlackBitched",
                table: "PlayerScore",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShotTheMoon",
                table: "PlayerScore",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DealerId",
                table: "GameRound",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoundNumber",
                table: "GameRound",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Game",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LoserId",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Game",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameRound_DealerId",
                table: "GameRound",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_LoserId",
                table: "Game",
                column: "LoserId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_WinnerId",
                table: "Game",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_LoserId",
                table: "Game",
                column: "LoserId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_WinnerId",
                table: "Game",
                column: "WinnerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRound_Player_DealerId",
                table: "GameRound",
                column: "DealerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_LoserId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_WinnerId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRound_Player_DealerId",
                table: "GameRound");

            migrationBuilder.DropIndex(
                name: "IX_GameRound_DealerId",
                table: "GameRound");

            migrationBuilder.DropIndex(
                name: "IX_Game_LoserId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_WinnerId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "BlackBitched",
                table: "PlayerScore");

            migrationBuilder.DropColumn(
                name: "ShotTheMoon",
                table: "PlayerScore");

            migrationBuilder.DropColumn(
                name: "DealerId",
                table: "GameRound");

            migrationBuilder.DropColumn(
                name: "RoundNumber",
                table: "GameRound");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "LoserId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Game");
        }
    }
}
