﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dnd_infra;

#nullable disable

namespace dnd_infra.Migrations
{
    [DbContext(typeof(GlobalDbContext))]
    [Migration("20230409152139_InitialMigrationWithArtefacts")]
    partial class InitialMigrationWithArtefacts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("dnd_infra.Items.DALs.ArtefactDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("CastDieToDiscardAfterUsage")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DiscardAfterUsage")
                        .HasColumnType("bit");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artefacts", "Items");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.ArtefactEffectDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtefactId")
                        .HasColumnType("int");

                    b.Property<bool?>("CanCastTrapFinderDie")
                        .HasColumnType("bit");

                    b.Property<bool?>("CanDiscardChestItemToPickAnotherOneOneTime")
                        .HasColumnType("bit");

                    b.Property<bool?>("CanDiscardChestItemToPickAnotherOneThreeTimes")
                        .HasColumnType("bit");

                    b.Property<bool?>("CanDiscardChestItemToPickAnotherOneTwoTimes")
                        .HasColumnType("bit");

                    b.Property<bool?>("CanInvokeHeroNearBy")
                        .HasColumnType("bit");

                    b.Property<bool?>("DismissAllAttacks")
                        .HasColumnType("bit");

                    b.Property<int?>("FootStepsDecrease")
                        .HasColumnType("int");

                    b.Property<int?>("FootStepsIncrease")
                        .HasColumnType("int");

                    b.Property<bool?>("IsUndetectableInNextRound")
                        .HasColumnType("bit");

                    b.Property<int?>("LifeDecrease")
                        .HasColumnType("int");

                    b.Property<int?>("LifeIncrease")
                        .HasColumnType("int");

                    b.Property<int?>("ManaDecrease")
                        .HasColumnType("int");

                    b.Property<int?>("ManaIncrease")
                        .HasColumnType("int");

                    b.Property<bool?>("NotAffectedByTraps")
                        .HasColumnType("bit");

                    b.Property<bool?>("NotAffectedByTrapsWhilePickingChestItems")
                        .HasColumnType("bit");

                    b.Property<bool?>("PicksTwoOutOfFourChestItems")
                        .HasColumnType("bit");

                    b.Property<bool?>("ReflectsBackToAnotherHero")
                        .HasColumnType("bit");

                    b.Property<bool?>("ReflectsBackToAttacker")
                        .HasColumnType("bit");

                    b.Property<bool?>("ReflectsBackToRandomTarget")
                        .HasColumnType("bit");

                    b.Property<bool?>("RerollDice")
                        .HasColumnType("bit");

                    b.Property<bool?>("RevealRoomTraps")
                        .HasColumnType("bit");

                    b.Property<int?>("ShieldDecrease")
                        .HasColumnType("int");

                    b.Property<int?>("ShieldIncrease")
                        .HasColumnType("int");

                    b.Property<int?>("StorageDecrease")
                        .HasColumnType("int");

                    b.Property<int?>("StorageIncrease")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtefactId");

                    b.ToTable("ArtefactEffects", "Items");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.ArtefactEffectDal", b =>
                {
                    b.HasOne("dnd_infra.Items.DALs.ArtefactDal", null)
                        .WithMany("Effects")
                        .HasForeignKey("ArtefactId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.ArtefactDal", b =>
                {
                    b.Navigation("Effects");
                });
#pragma warning restore 612, 618
        }
    }
}
