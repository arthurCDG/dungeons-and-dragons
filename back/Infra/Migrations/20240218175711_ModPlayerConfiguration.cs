using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations;

public partial class ModPlayerConfiguration : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "FirstName",
            schema: "Players",
            table: "PlayerProfiles");

        migrationBuilder.DropColumn(
            name: "LastName",
            schema: "Players",
            table: "PlayerProfiles");

        migrationBuilder.AlterColumn<string>(
            name: "PictureUrl",
            schema: "Users",
            table: "Users",
            type: "nvarchar(255)",
            maxLength: 255,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<byte[]>(
            name: "PasswordSalt",
            schema: "Users",
            table: "Users",
            type: "varbinary(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(byte[]),
            oldType: "varbinary(max)");

        migrationBuilder.AlterColumn<string>(
            name: "PasswordResetToken",
            schema: "Users",
            table: "Users",
            type: "nvarchar(255)",
            maxLength: 255,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<byte[]>(
            name: "PasswordHash",
            schema: "Users",
            table: "Users",
            type: "varbinary(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(byte[]),
            oldType: "varbinary(max)");

        migrationBuilder.AlterColumn<string>(
            name: "Password",
            schema: "Users",
            table: "Users",
            type: "nvarchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            schema: "Users",
            table: "Users",
            type: "nvarchar(55)",
            maxLength: 55,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "Role",
            schema: "Players",
            table: "PlayerProfiles",
            type: "nvarchar(55)",
            maxLength: 55,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "Race",
            schema: "Players",
            table: "PlayerProfiles",
            type: "nvarchar(55)",
            maxLength: 55,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "ImageUrl",
            schema: "Players",
            table: "PlayerProfiles",
            type: "nvarchar(255)",
            maxLength: 255,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Gender",
            schema: "Players",
            table: "PlayerProfiles",
            type: "nvarchar(55)",
            maxLength: 55,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "Class",
            schema: "Players",
            table: "PlayerProfiles",
            type: "nvarchar(55)",
            maxLength: 55,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AddColumn<string>(
            name: "Name",
            schema: "Players",
            table: "PlayerProfiles",
            type: "nvarchar(55)",
            maxLength: 55,
            nullable: false,
            defaultValue: "");
    }
}
