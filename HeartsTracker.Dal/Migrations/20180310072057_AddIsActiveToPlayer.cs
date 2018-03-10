using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HeartsTracker.Dal.Migrations
{
	public partial class AddIsActiveToPlayer : Migration
	{
		protected override void Up( MigrationBuilder migrationBuilder )
		{
			migrationBuilder.AddColumn<bool>(
				name: "IsActive",
				table: "Player",
				nullable: false,
				defaultValue: true );
		}

		protected override void Down( MigrationBuilder migrationBuilder )
		{
			migrationBuilder.DropColumn(
				name: "IsActive",
				table: "Player" );
		}
	}
}
