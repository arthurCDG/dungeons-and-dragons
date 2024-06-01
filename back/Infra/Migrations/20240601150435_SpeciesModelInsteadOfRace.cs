using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations;

public partial class SpeciesModelInsteadOfRace : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "Race",
            schema: "Players",
            table: "PlayerProfiles",
            newName: "Species");
    }
}
