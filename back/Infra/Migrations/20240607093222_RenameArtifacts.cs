using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class RenameArtifacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DieAssociations_Artefacts_ArtefactId",
                schema: "Dice",
                table: "DieAssociations");

            migrationBuilder.DropForeignKey(
                name: "FK_StoredItems_Artefacts_ArtefactId",
                schema: "Items",
                table: "StoredItems");

            migrationBuilder.DropTable(
                name: "ArtefactEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "Artefacts",
                schema: "Items");

            migrationBuilder.RenameColumn(
                name: "ArtefactId",
                schema: "Items",
                table: "StoredItems",
                newName: "ArtifactId");

            migrationBuilder.RenameIndex(
                name: "IX_StoredItems_ArtefactId",
                schema: "Items",
                table: "StoredItems",
                newName: "IX_StoredItems_ArtifactId");

            migrationBuilder.RenameColumn(
                name: "ArtefactId",
                schema: "Dice",
                table: "DieAssociations",
                newName: "ArtifactId");

            migrationBuilder.RenameIndex(
                name: "IX_DieAssociations_ArtefactId",
                schema: "Dice",
                table: "DieAssociations",
                newName: "IX_DieAssociations_ArtifactId");

            migrationBuilder.CreateTable(
                name: "Artifacts",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    DiscardAfterUsage = table.Column<bool>(type: "bit", nullable: true),
                    CastDieToDiscardAfterUsage = table.Column<bool>(type: "bit", nullable: true),
                    StarDieEffect = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artifacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtifactEffects",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtifactId = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtifactEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtifactEffects_Artifacts_ArtifactId",
                        column: x => x.ArtifactId,
                        principalSchema: "Items",
                        principalTable: "Artifacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtifactEffects_ArtifactId",
                schema: "Items",
                table: "ArtifactEffects",
                column: "ArtifactId");

            migrationBuilder.AddForeignKey(
                name: "FK_DieAssociations_Artifacts_ArtifactId",
                schema: "Dice",
                table: "DieAssociations",
                column: "ArtifactId",
                principalSchema: "Items",
                principalTable: "Artifacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoredItems_Artifacts_ArtifactId",
                schema: "Items",
                table: "StoredItems",
                column: "ArtifactId",
                principalSchema: "Items",
                principalTable: "Artifacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DieAssociations_Artifacts_ArtifactId",
                schema: "Dice",
                table: "DieAssociations");

            migrationBuilder.DropForeignKey(
                name: "FK_StoredItems_Artifacts_ArtifactId",
                schema: "Items",
                table: "StoredItems");

            migrationBuilder.DropTable(
                name: "ArtifactEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "Artifacts",
                schema: "Items");

            migrationBuilder.RenameColumn(
                name: "ArtifactId",
                schema: "Items",
                table: "StoredItems",
                newName: "ArtefactId");

            migrationBuilder.RenameIndex(
                name: "IX_StoredItems_ArtifactId",
                schema: "Items",
                table: "StoredItems",
                newName: "IX_StoredItems_ArtefactId");

            migrationBuilder.RenameColumn(
                name: "ArtifactId",
                schema: "Dice",
                table: "DieAssociations",
                newName: "ArtefactId");

            migrationBuilder.RenameIndex(
                name: "IX_DieAssociations_ArtifactId",
                schema: "Dice",
                table: "DieAssociations",
                newName: "IX_DieAssociations_ArtefactId");

            migrationBuilder.CreateTable(
                name: "Artefacts",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CastDieToDiscardAfterUsage = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscardAfterUsage = table.Column<bool>(type: "bit", nullable: true),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StarDieEffect = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artefacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtefactEffects",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtefactId = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtefactEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtefactEffects_Artefacts_ArtefactId",
                        column: x => x.ArtefactId,
                        principalSchema: "Items",
                        principalTable: "Artefacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtefactEffects_ArtefactId",
                schema: "Items",
                table: "ArtefactEffects",
                column: "ArtefactId");

            migrationBuilder.AddForeignKey(
                name: "FK_DieAssociations_Artefacts_ArtefactId",
                schema: "Dice",
                table: "DieAssociations",
                column: "ArtefactId",
                principalSchema: "Items",
                principalTable: "Artefacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoredItems_Artefacts_ArtefactId",
                schema: "Items",
                table: "StoredItems",
                column: "ArtefactId",
                principalSchema: "Items",
                principalTable: "Artefacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
