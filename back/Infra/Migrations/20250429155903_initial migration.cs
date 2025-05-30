﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Campaigns");

            migrationBuilder.EnsureSchema(
                name: "GameFlow");

            migrationBuilder.EnsureSchema(
                name: "Players");

            migrationBuilder.EnsureSchema(
                name: "Items");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", maxLength: 255, nullable: false),
                    PasswordResetToken = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", maxLength: 255, nullable: false),
                    PictureUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ResetTokenExpirationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                schema: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    StartsAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    DungeonMasterId = table.Column<int>(type: "integer", nullable: true),
                    EndsAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_Users_DungeonMasterId",
                        column: x => x.DungeonMasterId,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adventures",
                schema: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampaignId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    StartsAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndsAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                name: "Rooms",
                schema: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdventureId = table.Column<int>(type: "integer", nullable: false),
                    IsStartRoom = table.Column<bool>(type: "boolean", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    HasTopWall = table.Column<bool>(type: "boolean", nullable: true),
                    HasRightWall = table.Column<bool>(type: "boolean", nullable: true),
                    HasBottomWall = table.Column<bool>(type: "boolean", nullable: true),
                    HasLeftWall = table.Column<bool>(type: "boolean", nullable: true),
                    HasLockedChest = table.Column<bool>(type: "boolean", nullable: true),
                    HasOpenedChest = table.Column<bool>(type: "boolean", nullable: true),
                    HasPillar = table.Column<bool>(type: "boolean", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    IsDisabled = table.Column<bool>(type: "boolean", nullable: true),
                    IsDoor = table.Column<bool>(type: "boolean", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampaignId = table.Column<int>(type: "integer", nullable: true),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    IsDead = table.Column<bool>(type: "boolean", nullable: false),
                    SquareId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "Campaigns",
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SquareId = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SquareId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdventureId = table.Column<int>(type: "integer", nullable: false),
                    PlayerId = table.Column<int>(type: "integer", nullable: false)
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
                name: "PlayerAttributes",
                schema: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    LifePoints = table.Column<int>(type: "integer", nullable: false),
                    ManaPoints = table.Column<int>(type: "integer", nullable: false),
                    FootSteps = table.Column<int>(type: "integer", nullable: false),
                    Shield = table.Column<int>(type: "integer", nullable: false),
                    AttackCount = table.Column<int>(type: "integer", nullable: false),
                    HealCount = table.Column<int>(type: "integer", nullable: false),
                    ChestSearchCount = table.Column<int>(type: "integer", nullable: false),
                    TrapSearchCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerAttributes_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Players",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMaxAttributes",
                schema: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    MaxLifePoints = table.Column<int>(type: "integer", nullable: false),
                    MaxManaPoints = table.Column<int>(type: "integer", nullable: false),
                    MaxFootSteps = table.Column<int>(type: "integer", nullable: false),
                    MaxShield = table.Column<int>(type: "integer", nullable: false),
                    MaxAttackCount = table.Column<int>(type: "integer", nullable: false),
                    MaxHealCount = table.Column<int>(type: "integer", nullable: false),
                    MaxChestSearchCount = table.Column<int>(type: "integer", nullable: false),
                    MaxTrapSearchCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMaxAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMaxAttributes_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Players",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerProfiles",
                schema: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    Class = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    Gender = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    Species = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    Role = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerProfiles_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Players",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoredItems",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsEquiped = table.Column<bool>(type: "boolean", nullable: false),
                    ItemId = table.Column<string>(type: "text", nullable: false),
                    PlayerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoredItems_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Players",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurnOrders",
                schema: "GameFlow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    AdventureId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurnOrders_Adventures_AdventureId",
                        column: x => x.AdventureId,
                        principalSchema: "Campaigns",
                        principalTable: "Adventures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TurnOrders_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "Players",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adventures_CampaignId",
                schema: "Campaigns",
                table: "Adventures",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_DungeonMasterId",
                schema: "Campaigns",
                table: "Campaigns",
                column: "DungeonMasterId");

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
                name: "IX_PlayerAttributes_PlayerId",
                schema: "Players",
                table: "PlayerAttributes",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMaxAttributes_PlayerId",
                schema: "Players",
                table: "PlayerMaxAttributes",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerProfiles_PlayerId",
                schema: "Players",
                table: "PlayerProfiles",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_CampaignId",
                schema: "Players",
                table: "Players",
                column: "CampaignId");

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
                name: "IX_Rooms_AdventureId",
                schema: "Campaigns",
                table: "Rooms",
                column: "AdventureId");

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
                name: "IX_StoredItems_PlayerId",
                schema: "Items",
                table: "StoredItems",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnOrders_AdventureId",
                schema: "GameFlow",
                table: "TurnOrders",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnOrders_PlayerId",
                schema: "GameFlow",
                table: "TurnOrders",
                column: "PlayerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentPlayers",
                schema: "GameFlow");

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
                name: "Positions",
                schema: "Campaigns");

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
                name: "Players",
                schema: "Players");

            migrationBuilder.DropTable(
                name: "Squares",
                schema: "Campaigns");

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
                name: "Users",
                schema: "Users");
        }
    }
}
