using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations;

public partial class UseDateTimeOffSetsForCampaignsAsWell : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "StartsAt",
            schema: "Campaigns",
            table: "Campaigns",
            type: "datetimeoffset",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "datetime2(2)");

        migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "EndsAt",
            schema: "Campaigns",
            table: "Campaigns",
            type: "datetimeoffset",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime2(2)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Description",
            schema: "Campaigns",
            table: "Campaigns",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);
    }
}
