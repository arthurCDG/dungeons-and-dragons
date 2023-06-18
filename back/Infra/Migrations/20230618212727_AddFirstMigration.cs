using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Campaigns");

            migrationBuilder.EnsureSchema(
                name: "Items");

            migrationBuilder.EnsureSchema(
                name: "GameFlow");

            migrationBuilder.EnsureSchema(
                name: "Dice");

            migrationBuilder.EnsureSchema(
                name: "Players");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Artefacts",
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
                    table.PrimaryKey("PK_Artefacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                schema: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    StartsAt = table.Column<DateTime>(type: "datetime2(2)", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "datetime2(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChestTraps",
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
                    table.PrimaryKey("PK_ChestTraps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerAttributes",
                schema: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    LifePoints = table.Column<int>(type: "int", nullable: false),
                    ManaPoints = table.Column<int>(type: "int", nullable: false),
                    FootSteps = table.Column<int>(type: "int", nullable: false),
                    Shield = table.Column<int>(type: "int", nullable: false),
                    AttackCount = table.Column<int>(type: "int", nullable: false),
                    HealCount = table.Column<int>(type: "int", nullable: false),
                    ChestSearchCount = table.Column<int>(type: "int", nullable: false),
                    TrapSearchCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMaxAttributes",
                schema: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    MaxLifePoints = table.Column<int>(type: "int", nullable: false),
                    MaxManaPoints = table.Column<int>(type: "int", nullable: false),
                    MaxFootSteps = table.Column<int>(type: "int", nullable: false),
                    MaxShield = table.Column<int>(type: "int", nullable: false),
                    MaxAttackCount = table.Column<int>(type: "int", nullable: false),
                    MaxHealCount = table.Column<int>(type: "int", nullable: false),
                    MaxChestSearchCount = table.Column<int>(type: "int", nullable: false),
                    MaxTrapSearchCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMaxAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerProfiles",
                schema: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonsterType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Potions",
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
                    table.PrimaryKey("PK_Potions", x => x.Id);
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
                    IsMeleeSpell = table.Column<bool>(type: "bit", nullable: false),
                    IsDistantSpell = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Spells", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                name: "Adventures",
                schema: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adventures_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "Campaigns",
                        principalTable: "Campaigns",
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
                name: "UserCampaignAssociationDal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    CampaignDalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCampaignAssociationDal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCampaignAssociationDal_Campaigns_CampaignDalId",
                        column: x => x.CampaignDalId,
                        principalSchema: "Campaigns",
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCampaignAssociationDal_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "Campaigns",
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCampaignAssociationDal_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdventureId = table.Column<int>(type: "int", nullable: false),
                    IsStartRoom = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Adventures_AdventureId",
                        column: x => x.AdventureId,
                        principalSchema: "Campaigns",
                        principalTable: "Adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Squares",
                schema: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasTopWall = table.Column<bool>(type: "bit", nullable: true),
                    HasRightWall = table.Column<bool>(type: "bit", nullable: true),
                    HasBottomWall = table.Column<bool>(type: "bit", nullable: true),
                    HasLeftWall = table.Column<bool>(type: "bit", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: true),
                    IsDoor = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Squares_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "Campaigns",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdventureId = table.Column<int>(type: "int", nullable: false),
                    SquareId = table.Column<int>(type: "int", nullable: false),
                    IsDead = table.Column<bool>(type: "bit", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    AttributesId = table.Column<int>(type: "int", nullable: false),
                    MaxAttributesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Adventures_AdventureId",
                        column: x => x.AdventureId,
                        principalSchema: "Campaigns",
                        principalTable: "Adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_PlayerAttributes_AttributesId",
                        column: x => x.AttributesId,
                        principalSchema: "Players",
                        principalTable: "PlayerAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_PlayerMaxAttributes_MaxAttributesId",
                        column: x => x.MaxAttributesId,
                        principalSchema: "Players",
                        principalTable: "PlayerMaxAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_PlayerProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "Players",
                        principalTable: "PlayerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Squares_SquareId",
                        column: x => x.SquareId,
                        principalSchema: "Campaigns",
                        principalTable: "Squares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SquareId = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Squares_SquareId",
                        column: x => x.SquareId,
                        principalSchema: "Campaigns",
                        principalTable: "Squares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SquareTraps",
                schema: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SquareId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquareTraps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SquareTraps_Squares_SquareId",
                        column: x => x.SquareId,
                        principalSchema: "Campaigns",
                        principalTable: "Squares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrentPlayers",
                schema: "GameFlow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdventureId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentPlayers_Adventures_AdventureId",
                        column: x => x.AdventureId,
                        principalSchema: "Campaigns",
                        principalTable: "Adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Players",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TurnOrders",
                schema: "GameFlow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurnOrders_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Players",
                        principalTable: "Players",
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
                    DieType = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        name: "FK_DieAssociations_Spells_SpellId",
                        column: x => x.SpellId,
                        principalSchema: "Items",
                        principalTable: "Spells",
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
                    IsEquiped = table.Column<bool>(type: "bit", nullable: false),
                    IsDiscarded = table.Column<bool>(type: "bit", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_StoredItems_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Players",
                        principalTable: "Players",
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
                        name: "FK_StoredItems_Spells_SpellId",
                        column: x => x.SpellId,
                        principalSchema: "Items",
                        principalTable: "Spells",
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
                    table.PrimaryKey("PK_Weapons", x => x.Id);
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
                        name: "FK_WeaponSuperAttacks_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalSchema: "Items",
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adventures_CampaignId",
                schema: "Campaigns",
                table: "Adventures",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtefactEffects_ArtefactId",
                schema: "Items",
                table: "ArtefactEffects",
                column: "ArtefactId");

            migrationBuilder.CreateIndex(
                name: "IX_ChestTrapEffects_ChestTrapId",
                schema: "Items",
                table: "ChestTrapEffects",
                column: "ChestTrapId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentPlayers_AdventureId",
                schema: "GameFlow",
                table: "CurrentPlayers",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentPlayers_PlayerId",
                schema: "GameFlow",
                table: "CurrentPlayers",
                column: "PlayerId",
                unique: true);

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
                name: "IX_Players_AdventureId",
                schema: "Players",
                table: "Players",
                column: "AdventureId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Players_SquareId",
                schema: "Players",
                table: "Players",
                column: "SquareId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                schema: "Players",
                table: "Players",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_SquareId",
                schema: "Campaigns",
                table: "Positions",
                column: "SquareId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PotionEffects_PotionId",
                schema: "Items",
                table: "PotionEffects",
                column: "PotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AdventureId",
                schema: "Campaigns",
                table: "Rooms",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellEffects_SpellId",
                schema: "Items",
                table: "SpellEffects",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_Squares_RoomId",
                schema: "Campaigns",
                table: "Squares",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SquareTraps_SquareId",
                schema: "Campaigns",
                table: "SquareTraps",
                column: "SquareId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_ArtefactId",
                schema: "Items",
                table: "StoredItems",
                column: "ArtefactId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredItems_PlayerId",
                schema: "Items",
                table: "StoredItems",
                column: "PlayerId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TurnOrders_PlayerId",
                schema: "GameFlow",
                table: "TurnOrders",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignAssociationDal_CampaignDalId",
                table: "UserCampaignAssociationDal",
                column: "CampaignDalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignAssociationDal_CampaignId",
                table: "UserCampaignAssociationDal",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignAssociationDal_UserId",
                table: "UserCampaignAssociationDal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponEffects_WeaponId",
                schema: "Items",
                table: "WeaponEffects",
                column: "WeaponId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DieAssociations_WeaponSuperAttacks_WeaponSuperAttackId",
                schema: "Dice",
                table: "DieAssociations",
                column: "WeaponSuperAttackId",
                principalSchema: "Items",
                principalTable: "WeaponSuperAttacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DieAssociations_Weapons_WeaponId",
                schema: "Dice",
                table: "DieAssociations",
                column: "WeaponId",
                principalSchema: "Items",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoredItems_Weapons_WeaponId",
                schema: "Items",
                table: "StoredItems",
                column: "WeaponId",
                principalSchema: "Items",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeaponEffects_Weapons_WeaponId",
                schema: "Items",
                table: "WeaponEffects",
                column: "WeaponId",
                principalSchema: "Items",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_WeaponSuperAttacks_SuperAttackId",
                schema: "Items",
                table: "Weapons",
                column: "SuperAttackId",
                principalSchema: "Items",
                principalTable: "WeaponSuperAttacks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_WeaponSuperAttacks_SuperAttackId",
                schema: "Items",
                table: "Weapons");

            migrationBuilder.DropTable(
                name: "ArtefactEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "ChestTrapEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "CurrentPlayers",
                schema: "GameFlow");

            migrationBuilder.DropTable(
                name: "DieAssociations",
                schema: "Dice");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "Campaigns");

            migrationBuilder.DropTable(
                name: "PotionEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "SpellEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "SquareTraps",
                schema: "Campaigns");

            migrationBuilder.DropTable(
                name: "StoredItems",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "TurnOrders",
                schema: "GameFlow");

            migrationBuilder.DropTable(
                name: "UserCampaignAssociationDal");

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
                name: "Potions",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "Spells",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "Players");

            migrationBuilder.DropTable(
                name: "PlayerAttributes",
                schema: "Players");

            migrationBuilder.DropTable(
                name: "PlayerMaxAttributes",
                schema: "Players");

            migrationBuilder.DropTable(
                name: "PlayerProfiles",
                schema: "Players");

            migrationBuilder.DropTable(
                name: "Squares",
                schema: "Campaigns");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "Campaigns");

            migrationBuilder.DropTable(
                name: "Adventures",
                schema: "Campaigns");

            migrationBuilder.DropTable(
                name: "Campaigns",
                schema: "Campaigns");

            migrationBuilder.DropTable(
                name: "WeaponSuperAttacks",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "Weapons",
                schema: "Items");
        }
    }
}
