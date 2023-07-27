using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class AddAdventureStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Campaigns",
                table: "Adventures");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                schema: "Campaigns",
                table: "Adventures");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "Campaigns",
                table: "Adventures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Campaigns",
                table: "Adventures");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Campaigns",
                table: "Adventures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                schema: "Campaigns",
                table: "Adventures",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
