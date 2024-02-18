using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace dnd_infra.Migrations;

public partial class AddPasswordHash : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<byte[]>(
            name: "PasswordHash",
            schema: "Users",
            table: "Users",
            type: "varbinary(max)",
            nullable: false,
            defaultValue: new byte[0]);

        migrationBuilder.AddColumn<string>(
            name: "PasswordResetToken",
            schema: "Users",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<byte[]>(
            name: "PasswordSalt",
            schema: "Users",
            table: "Users",
            type: "varbinary(max)",
            nullable: false,
            defaultValue: new byte[0]);

        migrationBuilder.AddColumn<DateTimeOffset>(
            name: "ResetTokenExpirationDate",
            schema: "Users",
            table: "Users",
            type: "datetimeoffset",
            nullable: true);
    }
}
