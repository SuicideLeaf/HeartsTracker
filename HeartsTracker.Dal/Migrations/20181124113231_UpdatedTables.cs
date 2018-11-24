using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeartsTracker.Dal.Migrations
{
    public partial class UpdatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_LoserId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_WinnerId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayer_Game_GameId",
                table: "GamePlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayer_Player_PlayerId",
                table: "GamePlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRound_Player_DealerId",
                table: "GameRound");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRound_Game_GameId",
                table: "GameRound");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerScore_GameRound_GameRoundId",
                table: "PlayerScore");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerScore_Player_PlayerId",
                table: "PlayerScore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerScore",
                table: "PlayerScore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameRound",
                table: "GameRound");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamePlayer",
                table: "GamePlayer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "PlayerScore",
                newName: "PlayerScores");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "GameRound",
                newName: "GameRounds");

            migrationBuilder.RenameTable(
                name: "GamePlayer",
                newName: "GamePlayers");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerScore_GameRoundId",
                table: "PlayerScores",
                newName: "IX_PlayerScores_GameRoundId");

            migrationBuilder.RenameIndex(
                name: "IX_GameRound_GameId",
                table: "GameRounds",
                newName: "IX_GameRounds_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameRound_DealerId",
                table: "GameRounds",
                newName: "IX_GameRounds_DealerId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlayer_PlayerId",
                table: "GamePlayers",
                newName: "IX_GamePlayers_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_WinnerId",
                table: "Games",
                newName: "IX_Games_WinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_LoserId",
                table: "Games",
                newName: "IX_Games_LoserId");

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "GameRounds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "GamePlayers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDateTime",
                table: "Games",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerScores",
                table: "PlayerScores",
                columns: new[] { "PlayerId", "RoundId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameRounds",
                table: "GameRounds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamePlayers",
                table: "GamePlayers",
                columns: new[] { "GameId", "PlayerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayers_Games_GameId",
                table: "GamePlayers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayers_Players_PlayerId",
                table: "GamePlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRounds_Players_DealerId",
                table: "GameRounds",
                column: "DealerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRounds_Games_GameId",
                table: "GameRounds",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_LoserId",
                table: "Games",
                column: "LoserId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_WinnerId",
                table: "Games",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerScores_GameRounds_GameRoundId",
                table: "PlayerScores",
                column: "GameRoundId",
                principalTable: "GameRounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerScores_Players_PlayerId",
                table: "PlayerScores",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayers_Games_GameId",
                table: "GamePlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayers_Players_PlayerId",
                table: "GamePlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRounds_Players_DealerId",
                table: "GameRounds");

            migrationBuilder.DropForeignKey(
                name: "FK_GameRounds_Games_GameId",
                table: "GameRounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_LoserId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_WinnerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerScores_GameRounds_GameRoundId",
                table: "PlayerScores");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerScores_Players_PlayerId",
                table: "PlayerScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerScores",
                table: "PlayerScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameRounds",
                table: "GameRounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamePlayers",
                table: "GamePlayers");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "GameRounds");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "GamePlayers");

            migrationBuilder.RenameTable(
                name: "PlayerScores",
                newName: "PlayerScore");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameTable(
                name: "GameRounds",
                newName: "GameRound");

            migrationBuilder.RenameTable(
                name: "GamePlayers",
                newName: "GamePlayer");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerScores_GameRoundId",
                table: "PlayerScore",
                newName: "IX_PlayerScore_GameRoundId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_WinnerId",
                table: "Game",
                newName: "IX_Game_WinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_LoserId",
                table: "Game",
                newName: "IX_Game_LoserId");

            migrationBuilder.RenameIndex(
                name: "IX_GameRounds_GameId",
                table: "GameRound",
                newName: "IX_GameRound_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameRounds_DealerId",
                table: "GameRound",
                newName: "IX_GameRound_DealerId");

            migrationBuilder.RenameIndex(
                name: "IX_GamePlayers_PlayerId",
                table: "GamePlayer",
                newName: "IX_GamePlayer_PlayerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDateTime",
                table: "Game",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerScore",
                table: "PlayerScore",
                columns: new[] { "PlayerId", "RoundId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameRound",
                table: "GameRound",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamePlayer",
                table: "GamePlayer",
                columns: new[] { "GameId", "PlayerId" });

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
                name: "FK_GamePlayer_Game_GameId",
                table: "GamePlayer",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayer_Player_PlayerId",
                table: "GamePlayer",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRound_Player_DealerId",
                table: "GameRound",
                column: "DealerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameRound_Game_GameId",
                table: "GameRound",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerScore_GameRound_GameRoundId",
                table: "PlayerScore",
                column: "GameRoundId",
                principalTable: "GameRound",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerScore_Player_PlayerId",
                table: "PlayerScore",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
