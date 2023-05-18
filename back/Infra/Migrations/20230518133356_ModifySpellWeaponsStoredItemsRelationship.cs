using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class ModifySpellWeaponsStoredItemsRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StoredItems_ArtefactId",
                schema: "Items",
                table: "StoredItems");

            migrationBuilder.DropIndex(
                name: "IX_StoredItems_PotionId",
                schema: "Items",
                table: "StoredItems");

            migrationBuilder.DropIndex(
                name: "IX_StoredItems_SpellId",
                schema: "Items",
                table: "StoredItems");

            migrationBuilder.DropIndex(
                name: "IX_StoredItems_WeaponId",
                schema: "Items",
                table: "StoredItems");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_ArtefactId",
                schema: "Items",
                table: "StoredItems",
                column: "ArtefactId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_PotionId",
                schema: "Items",
                table: "StoredItems",
                column: "PotionId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_SpellId",
                schema: "Items",
                table: "StoredItems",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_WeaponId",
                schema: "Items",
                table: "StoredItems",
                column: "WeaponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StoredItems_ArtefactId",
                schema: "Items",
                table: "StoredItems");

            migrationBuilder.DropIndex(
                name: "IX_StoredItems_PotionId",
                schema: "Items",
                table: "StoredItems");

            migrationBuilder.DropIndex(
                name: "IX_StoredItems_SpellId",
                schema: "Items",
                table: "StoredItems");

            migrationBuilder.DropIndex(
                name: "IX_StoredItems_WeaponId",
                schema: "Items",
                table: "StoredItems");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_ArtefactId",
                schema: "Items",
                table: "StoredItems",
                column: "ArtefactId",
                unique: true,
                filter: "[ArtefactId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_PotionId",
                schema: "Items",
                table: "StoredItems",
                column: "PotionId",
                unique: true,
                filter: "[PotionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_SpellId",
                schema: "Items",
                table: "StoredItems",
                column: "SpellId",
                unique: true,
                filter: "[SpellId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_WeaponId",
                schema: "Items",
                table: "StoredItems",
                column: "WeaponId",
                unique: true,
                filter: "[WeaponId] IS NOT NULL");
        }
    }
}
