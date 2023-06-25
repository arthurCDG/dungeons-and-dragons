using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class AddFKsOnPlayersTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerAttributes_AttributesId",
                schema: "Players",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerMaxAttributes_MaxAttributesId",
                schema: "Players",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerProfiles_ProfileId",
                schema: "Players",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_AttributesId",
                schema: "Players",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_MaxAttributesId",
                schema: "Players",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_ProfileId",
                schema: "Players",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AttributesId",
                schema: "Players",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "MaxAttributesId",
                schema: "Players",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                schema: "Players",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                schema: "Players",
                table: "PlayerProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerProfiles_PlayerId",
                schema: "Players",
                table: "PlayerProfiles",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMaxAttributes_PlayerId",
                schema: "Players",
                table: "PlayerMaxAttributes",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerAttributes_PlayerId",
                schema: "Players",
                table: "PlayerAttributes",
                column: "PlayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerAttributes_Players_PlayerId",
                schema: "Players",
                table: "PlayerAttributes",
                column: "PlayerId",
                principalSchema: "Players",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMaxAttributes_Players_PlayerId",
                schema: "Players",
                table: "PlayerMaxAttributes",
                column: "PlayerId",
                principalSchema: "Players",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerProfiles_Players_PlayerId",
                schema: "Players",
                table: "PlayerProfiles",
                column: "PlayerId",
                principalSchema: "Players",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerAttributes_Players_PlayerId",
                schema: "Players",
                table: "PlayerAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMaxAttributes_Players_PlayerId",
                schema: "Players",
                table: "PlayerMaxAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerProfiles_Players_PlayerId",
                schema: "Players",
                table: "PlayerProfiles");

            migrationBuilder.DropIndex(
                name: "IX_PlayerProfiles_PlayerId",
                schema: "Players",
                table: "PlayerProfiles");

            migrationBuilder.DropIndex(
                name: "IX_PlayerMaxAttributes_PlayerId",
                schema: "Players",
                table: "PlayerMaxAttributes");

            migrationBuilder.DropIndex(
                name: "IX_PlayerAttributes_PlayerId",
                schema: "Players",
                table: "PlayerAttributes");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                schema: "Players",
                table: "PlayerProfiles");

            migrationBuilder.AddColumn<int>(
                name: "AttributesId",
                schema: "Players",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxAttributesId",
                schema: "Players",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                schema: "Players",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_AttributesId",
                schema: "Players",
                table: "Players",
                column: "AttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_MaxAttributesId",
                schema: "Players",
                table: "Players",
                column: "MaxAttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ProfileId",
                schema: "Players",
                table: "Players",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerAttributes_AttributesId",
                schema: "Players",
                table: "Players",
                column: "AttributesId",
                principalSchema: "Players",
                principalTable: "PlayerAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerMaxAttributes_MaxAttributesId",
                schema: "Players",
                table: "Players",
                column: "MaxAttributesId",
                principalSchema: "Players",
                principalTable: "PlayerMaxAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerProfiles_ProfileId",
                schema: "Players",
                table: "Players",
                column: "ProfileId",
                principalSchema: "Players",
                principalTable: "PlayerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
