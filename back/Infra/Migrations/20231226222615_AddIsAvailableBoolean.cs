using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations;

public partial class AddIsAvailableBoolean : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<bool>(
            name: "IsAvailable",
            schema: "Users",
            table: "Users",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<bool>(
            name: "IsAvailable",
            schema: "Players",
            table: "Players",
            type: "bit",
            nullable: false,
            defaultValue: false);
    }
}
