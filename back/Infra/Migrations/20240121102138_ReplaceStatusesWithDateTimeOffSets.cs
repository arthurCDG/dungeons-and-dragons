using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations;

public partial class ReplaceStatusesWithDateTimeOffSets : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Status",
            schema: "Campaigns",
            table: "Adventures");

        migrationBuilder.AddColumn<DateTimeOffset>(
            name: "EndsAt",
            schema: "Campaigns",
            table: "Adventures",
            type: "datetimeoffset",
            nullable: true);

        migrationBuilder.AddColumn<DateTimeOffset>(
            name: "StartsAt",
            schema: "Campaigns",
            table: "Adventures",
            type: "datetimeoffset",
            nullable: false,
            defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
    }
}
