using Microsoft.EntityFrameworkCore.Migrations;

namespace HeartsTracker.Dal.Migrations
{
	public partial class AddedIsActiveFlagToGameTable : Migration
	{
		protected override void Up( MigrationBuilder migrationBuilder )
		{
			migrationBuilder.AddColumn<bool>(
				name: "IsActive",
				table: "Game",
				nullable: false,
				defaultValue: true );
		}

		protected override void Down( MigrationBuilder migrationBuilder )
		{
			migrationBuilder.DropColumn(
				name: "IsActive",
				table: "Game" );
		}
	}
}