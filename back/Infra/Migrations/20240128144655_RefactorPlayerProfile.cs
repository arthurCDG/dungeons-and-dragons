using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations;

public partial class RefactorPlayerProfile : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "MonsterType",
            schema: "Players",
            table: "PlayerProfiles");

        migrationBuilder.AlterColumn<string>(
            name: "Race",
            schema: "Players",
            table: "PlayerProfiles",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "ImageUrl",
            schema: "Players",
            table: "PlayerProfiles",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "Class",
            schema: "Players",
            table: "PlayerProfiles",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Role",
            schema: "Players",
            table: "PlayerProfiles",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");
    }
}
