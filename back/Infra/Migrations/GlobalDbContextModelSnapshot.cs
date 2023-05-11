﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dnd_infra;

#nullable disable

namespace dnd_infra.Migrations
{
    [DbContext(typeof(GlobalDbContext))]
    partial class GlobalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("dnd_infra.Dice.DieAssociationDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtefactId")
                        .HasColumnType("int");

                    b.Property<int?>("ChestTrapId")
                        .HasColumnType("int");

                    b.Property<int>("DieType")
                        .HasColumnType("int");

                    b.Property<int?>("PotionId")
                        .HasColumnType("int");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int?>("SpellId")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponSuperAttackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtefactId");

                    b.HasIndex("ChestTrapId");

                    b.HasIndex("PotionId");

                    b.HasIndex("SessionId");

                    b.HasIndex("SpellId");

                    b.HasIndex("WeaponId");

                    b.HasIndex("WeaponSuperAttackId");

                    b.ToTable("DieAssociations", "Dice");
                });

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

                    b.Property<bool>("DiscardAfterUsage")
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

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

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

                    b.Property<string>("Effect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtefactId");

                    b.ToTable("ArtefactEffects", "Items");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.ChestTrapDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("ChestTraps", "Items");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.ChestTrapEffectDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChestTrapId")
                        .HasColumnType("int");

                    b.Property<string>("Effect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChestTrapId");

                    b.ToTable("ChestTrapEffects", "Items");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.PotionDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DiscardAfterUsage")
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

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Potions", "Items");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.PotionEffectDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Effect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PotionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PotionId");

                    b.ToTable("PotionEffects", "Items");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.SpellDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDistantSpell")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMeleeSpell")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("ManaCost")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int?>("StarDieEffect")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Spells", "Items");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.SpellEffectDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Effect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpellId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpellId");

                    b.ToTable("SpellEffects", "Items");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.StoredItemDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtefactId")
                        .HasColumnType("int");

                    b.Property<int?>("HeroId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDiscarded")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEquiped")
                        .HasColumnType("bit");

                    b.Property<int?>("MonsterId")
                        .HasColumnType("int");

                    b.Property<int?>("PotionId")
                        .HasColumnType("int");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int?>("SpellId")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtefactId")
                        .IsUnique()
                        .HasFilter("[ArtefactId] IS NOT NULL");

                    b.HasIndex("HeroId");

                    b.HasIndex("MonsterId");

                    b.HasIndex("PotionId")
                        .IsUnique()
                        .HasFilter("[PotionId] IS NOT NULL");

                    b.HasIndex("SessionId");

                    b.HasIndex("SpellId")
                        .IsUnique()
                        .HasFilter("[SpellId] IS NOT NULL");

                    b.HasIndex("WeaponId")
                        .IsUnique()
                        .HasFilter("[WeaponId] IS NOT NULL");

                    b.ToTable("StoredItems", "Items");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.WeaponDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("CanRerollOneDie")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int?>("StarDieEffect")
                        .HasColumnType("int");

                    b.Property<int?>("SuperAttackId")
                        .HasColumnType("int");

                    b.Property<int>("WeaponType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.HasIndex("SuperAttackId");

                    b.ToTable("Weapons", "Items");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.WeaponEffectDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Effect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WeaponId");

                    b.ToTable("WeaponEffects", "Items");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.WeaponSuperAttackDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("LosesWeaponAfterSuperAttack")
                        .HasColumnType("bit");

                    b.Property<bool?>("LosesWeaponIfStarDieReturnsStar")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WeaponId")
                        .IsUnique();

                    b.ToTable("WeaponSuperAttacks", "Items");
                });

            modelBuilder.Entity("dnd_infra.Players.DALs.HeroDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int>("FootSteps")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDead")
                        .HasColumnType("bit");

                    b.Property<int>("LifePoints")
                        .HasColumnType("int");

                    b.Property<int>("ManaPoints")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Race")
                        .HasColumnType("int");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("Shield")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Heroes", "Players");
                });

            modelBuilder.Entity("dnd_infra.Players.DALs.MonsterDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FootSteps")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDead")
                        .HasColumnType("bit");

                    b.Property<int>("LifePoints")
                        .HasColumnType("int");

                    b.Property<int>("ManaPoints")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("Shield")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Monsters", "Players");
                });

            modelBuilder.Entity("dnd_infra.Sessions.SessionDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndsAt")
                        .HasColumnType("datetime2(2)");

                    b.Property<DateTime>("StartsAt")
                        .HasColumnType("datetime2(2)");

                    b.HasKey("Id");

                    b.ToTable("Sessions", "dbo");
                });

            modelBuilder.Entity("dnd_infra.Dice.DieAssociationDal", b =>
                {
                    b.HasOne("dnd_infra.Items.DALs.ArtefactDal", null)
                        .WithMany()
                        .HasForeignKey("ArtefactId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("dnd_infra.Items.DALs.ChestTrapDal", null)
                        .WithMany()
                        .HasForeignKey("ChestTrapId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("dnd_infra.Items.DALs.PotionDal", null)
                        .WithMany()
                        .HasForeignKey("PotionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("dnd_infra.Sessions.SessionDal", null)
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("dnd_infra.Items.DALs.SpellDal", null)
                        .WithMany("Dice")
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("dnd_infra.Items.DALs.WeaponDal", null)
                        .WithMany("Dice")
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("dnd_infra.Items.DALs.WeaponSuperAttackDal", null)
                        .WithMany("Dice")
                        .HasForeignKey("WeaponSuperAttackId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.ArtefactDal", b =>
                {
                    b.HasOne("dnd_infra.Sessions.SessionDal", null)
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.ArtefactEffectDal", b =>
                {
                    b.HasOne("dnd_infra.Items.DALs.ArtefactDal", null)
                        .WithMany("Effects")
                        .HasForeignKey("ArtefactId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.ChestTrapDal", b =>
                {
                    b.HasOne("dnd_infra.Sessions.SessionDal", null)
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.ChestTrapEffectDal", b =>
                {
                    b.HasOne("dnd_infra.Items.DALs.ChestTrapDal", null)
                        .WithMany("Effects")
                        .HasForeignKey("ChestTrapId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.PotionDal", b =>
                {
                    b.HasOne("dnd_infra.Sessions.SessionDal", null)
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.PotionEffectDal", b =>
                {
                    b.HasOne("dnd_infra.Items.DALs.PotionDal", null)
                        .WithMany("Effects")
                        .HasForeignKey("PotionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.SpellDal", b =>
                {
                    b.HasOne("dnd_infra.Sessions.SessionDal", null)
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.SpellEffectDal", b =>
                {
                    b.HasOne("dnd_infra.Items.DALs.SpellDal", null)
                        .WithMany("Effects")
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.StoredItemDal", b =>
                {
                    b.HasOne("dnd_infra.Items.DALs.ArtefactDal", "Artefact")
                        .WithOne()
                        .HasForeignKey("dnd_infra.Items.DALs.StoredItemDal", "ArtefactId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("dnd_infra.Players.DALs.HeroDal", null)
                        .WithMany("StoredItems")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("dnd_infra.Players.DALs.MonsterDal", null)
                        .WithMany("StoredItems")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("dnd_infra.Items.DALs.PotionDal", "Potion")
                        .WithOne()
                        .HasForeignKey("dnd_infra.Items.DALs.StoredItemDal", "PotionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("dnd_infra.Sessions.SessionDal", null)
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("dnd_infra.Items.DALs.SpellDal", "Spell")
                        .WithOne()
                        .HasForeignKey("dnd_infra.Items.DALs.StoredItemDal", "SpellId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("dnd_infra.Items.DALs.WeaponDal", "Weapon")
                        .WithOne()
                        .HasForeignKey("dnd_infra.Items.DALs.StoredItemDal", "WeaponId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Artefact");

                    b.Navigation("Potion");

                    b.Navigation("Spell");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.WeaponDal", b =>
                {
                    b.HasOne("dnd_infra.Sessions.SessionDal", null)
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("dnd_infra.Items.DALs.WeaponSuperAttackDal", "SuperAttack")
                        .WithMany()
                        .HasForeignKey("SuperAttackId");

                    b.Navigation("SuperAttack");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.WeaponEffectDal", b =>
                {
                    b.HasOne("dnd_infra.Items.DALs.WeaponDal", null)
                        .WithMany("Effects")
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.WeaponSuperAttackDal", b =>
                {
                    b.HasOne("dnd_infra.Items.DALs.WeaponDal", null)
                        .WithOne()
                        .HasForeignKey("dnd_infra.Items.DALs.WeaponSuperAttackDal", "WeaponId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("dnd_infra.Players.DALs.HeroDal", b =>
                {
                    b.HasOne("dnd_infra.Sessions.SessionDal", null)
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("dnd_infra.Players.DALs.MonsterDal", b =>
                {
                    b.HasOne("dnd_infra.Sessions.SessionDal", null)
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.ArtefactDal", b =>
                {
                    b.Navigation("Effects");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.ChestTrapDal", b =>
                {
                    b.Navigation("Effects");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.PotionDal", b =>
                {
                    b.Navigation("Effects");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.SpellDal", b =>
                {
                    b.Navigation("Dice");

                    b.Navigation("Effects");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.WeaponDal", b =>
                {
                    b.Navigation("Dice");

                    b.Navigation("Effects");
                });

            modelBuilder.Entity("dnd_infra.Items.DALs.WeaponSuperAttackDal", b =>
                {
                    b.Navigation("Dice");
                });

            modelBuilder.Entity("dnd_infra.Players.DALs.HeroDal", b =>
                {
                    b.Navigation("StoredItems");
                });

            modelBuilder.Entity("dnd_infra.Players.DALs.MonsterDal", b =>
                {
                    b.Navigation("StoredItems");
                });
#pragma warning restore 612, 618
        }
    }
}
