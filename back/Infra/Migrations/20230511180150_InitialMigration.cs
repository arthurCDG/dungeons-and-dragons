using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Items");

            migrationBuilder.EnsureSchema(
                name: "Dice");

            migrationBuilder.EnsureSchema(
                name: "Players");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Sessions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartsAt = table.Column<DateTime>(type: "datetime2(2)", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "datetime2(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponSuperAttacks",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    LosesWeaponAfterSuperAttack = table.Column<bool>(type: "bit", nullable: true),
                    LosesWeaponIfStarDieReturnsStar = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponSuperAttacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeaponSuperAttacks_WeaponSuperAttacks_WeaponId",
                        column: x => x.WeaponId,
                        principalSchema: "Items",
                        principalTable: "WeaponSuperAttacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artefacts",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscardAfterUsage = table.Column<bool>(type: "bit", nullable: false),
                    CastDieToDiscardAfterUsage = table.Column<bool>(type: "bit", nullable: true),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artefacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artefacts_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalSchema: "dbo",
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChestTraps",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChestTraps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChestTraps_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalSchema: "dbo",
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                schema: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Race = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifePoints = table.Column<int>(type: "int", nullable: false),
                    ManaPoints = table.Column<int>(type: "int", nullable: false),
                    FootSteps = table.Column<int>(type: "int", nullable: false),
                    Shield = table.Column<int>(type: "int", nullable: false),
                    IsDead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalSchema: "dbo",
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Monsters",
                schema: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifePoints = table.Column<int>(type: "int", nullable: false),
                    ManaPoints = table.Column<int>(type: "int", nullable: false),
                    FootSteps = table.Column<int>(type: "int", nullable: false),
                    Shield = table.Column<int>(type: "int", nullable: false),
                    IsDead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monsters_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalSchema: "dbo",
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Potions",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscardAfterUsage = table.Column<bool>(type: "bit", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Potions_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalSchema: "dbo",
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManaCost = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StarDieEffect = table.Column<int>(type: "int", nullable: true),
                    IsMeleeSpell = table.Column<bool>(type: "bit", nullable: false),
                    IsDistantSpell = table.Column<bool>(type: "bit", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spells_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalSchema: "dbo",
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponType = table.Column<int>(type: "int", nullable: false),
                    SuperAttackId = table.Column<int>(type: "int", nullable: true),
                    CanRerollOneDie = table.Column<bool>(type: "bit", nullable: true),
                    StarDieEffect = table.Column<int>(type: "int", nullable: true),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalSchema: "dbo",
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weapons_WeaponSuperAttacks_SuperAttackId",
                        column: x => x.SuperAttackId,
                        principalSchema: "Items",
                        principalTable: "WeaponSuperAttacks",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "ChestTrapEffects",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChestTrapId = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChestTrapEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChestTrapEffects_ChestTraps_ChestTrapId",
                        column: x => x.ChestTrapId,
                        principalSchema: "Items",
                        principalTable: "ChestTraps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PotionEffects",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PotionId = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotionEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PotionEffects_Potions_PotionId",
                        column: x => x.PotionId,
                        principalSchema: "Items",
                        principalTable: "Potions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpellEffects",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpellId = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellEffects_Spells_SpellId",
                        column: x => x.SpellId,
                        principalSchema: "Items",
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DieAssociations",
                schema: "Dice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    DieType = table.Column<int>(type: "int", nullable: false),
                    ArtefactId = table.Column<int>(type: "int", nullable: true),
                    ChestTrapId = table.Column<int>(type: "int", nullable: true),
                    PotionId = table.Column<int>(type: "int", nullable: true),
                    SpellId = table.Column<int>(type: "int", nullable: true),
                    WeaponId = table.Column<int>(type: "int", nullable: true),
                    WeaponSuperAttackId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DieAssociations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DieAssociations_Artefacts_ArtefactId",
                        column: x => x.ArtefactId,
                        principalSchema: "Items",
                        principalTable: "Artefacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieAssociations_ChestTraps_ChestTrapId",
                        column: x => x.ChestTrapId,
                        principalSchema: "Items",
                        principalTable: "ChestTraps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieAssociations_Potions_PotionId",
                        column: x => x.PotionId,
                        principalSchema: "Items",
                        principalTable: "Potions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieAssociations_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalSchema: "dbo",
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieAssociations_Spells_SpellId",
                        column: x => x.SpellId,
                        principalSchema: "Items",
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieAssociations_WeaponSuperAttacks_WeaponSuperAttackId",
                        column: x => x.WeaponSuperAttackId,
                        principalSchema: "Items",
                        principalTable: "WeaponSuperAttacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DieAssociations_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalSchema: "Items",
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoredItems",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    IsEquiped = table.Column<bool>(type: "bit", nullable: false),
                    IsDiscarded = table.Column<bool>(type: "bit", nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: true),
                    MonsterId = table.Column<int>(type: "int", nullable: true),
                    ArtefactId = table.Column<int>(type: "int", nullable: true),
                    PotionId = table.Column<int>(type: "int", nullable: true),
                    SpellId = table.Column<int>(type: "int", nullable: true),
                    WeaponId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoredItems_Artefacts_ArtefactId",
                        column: x => x.ArtefactId,
                        principalSchema: "Items",
                        principalTable: "Artefacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoredItems_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalSchema: "Players",
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoredItems_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "Players",
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoredItems_Potions_PotionId",
                        column: x => x.PotionId,
                        principalSchema: "Items",
                        principalTable: "Potions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoredItems_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalSchema: "dbo",
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoredItems_Spells_SpellId",
                        column: x => x.SpellId,
                        principalSchema: "Items",
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoredItems_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalSchema: "Items",
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeaponEffects",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponId = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeaponEffects_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalSchema: "Items",
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtefactEffects_ArtefactId",
                schema: "Items",
                table: "ArtefactEffects",
                column: "ArtefactId");

            migrationBuilder.CreateIndex(
                name: "IX_Artefacts_SessionId",
                schema: "Items",
                table: "Artefacts",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChestTrapEffects_ChestTrapId",
                schema: "Items",
                table: "ChestTrapEffects",
                column: "ChestTrapId");

            migrationBuilder.CreateIndex(
                name: "IX_ChestTraps_SessionId",
                schema: "Items",
                table: "ChestTraps",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_DieAssociations_ArtefactId",
                schema: "Dice",
                table: "DieAssociations",
                column: "ArtefactId");

            migrationBuilder.CreateIndex(
                name: "IX_DieAssociations_ChestTrapId",
                schema: "Dice",
                table: "DieAssociations",
                column: "ChestTrapId");

            migrationBuilder.CreateIndex(
                name: "IX_DieAssociations_PotionId",
                schema: "Dice",
                table: "DieAssociations",
                column: "PotionId");

            migrationBuilder.CreateIndex(
                name: "IX_DieAssociations_SessionId",
                schema: "Dice",
                table: "DieAssociations",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_DieAssociations_SpellId",
                schema: "Dice",
                table: "DieAssociations",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_DieAssociations_WeaponId",
                schema: "Dice",
                table: "DieAssociations",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_DieAssociations_WeaponSuperAttackId",
                schema: "Dice",
                table: "DieAssociations",
                column: "WeaponSuperAttackId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_SessionId",
                schema: "Players",
                table: "Heroes",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_SessionId",
                schema: "Players",
                table: "Monsters",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PotionEffects_PotionId",
                schema: "Items",
                table: "PotionEffects",
                column: "PotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Potions_SessionId",
                schema: "Items",
                table: "Potions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellEffects_SpellId",
                schema: "Items",
                table: "SpellEffects",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_SessionId",
                schema: "Items",
                table: "Spells",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_ArtefactId",
                schema: "Items",
                table: "StoredItems",
                column: "ArtefactId",
                unique: true,
                filter: "[ArtefactId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_HeroId",
                schema: "Items",
                table: "StoredItems",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_MonsterId",
                schema: "Items",
                table: "StoredItems",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_PotionId",
                schema: "Items",
                table: "StoredItems",
                column: "PotionId",
                unique: true,
                filter: "[PotionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_SessionId",
                schema: "Items",
                table: "StoredItems",
                column: "SessionId");

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

            migrationBuilder.CreateIndex(
                name: "IX_WeaponEffects_WeaponId",
                schema: "Items",
                table: "WeaponEffects",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_SessionId",
                schema: "Items",
                table: "Weapons",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_SuperAttackId",
                schema: "Items",
                table: "Weapons",
                column: "SuperAttackId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponSuperAttacks_WeaponId",
                schema: "Items",
                table: "WeaponSuperAttacks",
                column: "WeaponId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtefactEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "ChestTrapEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "DieAssociations",
                schema: "Dice");

            migrationBuilder.DropTable(
                name: "PotionEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "SpellEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "StoredItems",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "WeaponEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "ChestTraps",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "Artefacts",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "Heroes",
                schema: "Players");

            migrationBuilder.DropTable(
                name: "Monsters",
                schema: "Players");

            migrationBuilder.DropTable(
                name: "Potions",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "Spells",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "Weapons",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "Sessions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WeaponSuperAttacks",
                schema: "Items");
        }
    }
}
