﻿// <auto-generated />
using System;
using ActionCommandGame.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ActionCommandGame.Ui.WebApp.Migrations
{
    [DbContext(typeof(ActionButtonGameDbContext))]
    [Migration("20210509135355_FirstTimeAddingTables")]
    partial class FirstTimeAddingTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ActionCommandGame.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionCooldownSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fuel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ActionCommandGame.Model.NegativeGameEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DefenseLoss")
                        .HasColumnType("int");

                    b.Property<string>("DefenseWithGearDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefenseWithoutGearDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Probability")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NegativeGameEvents");
                });

            modelBuilder.Entity("ActionCommandGame.Model.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CurrentAttackPlayerItemId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentDefensePlayerItemId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentFuelPlayerItemId")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastActionExecutedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentAttackPlayerItemId");

                    b.HasIndex("CurrentDefensePlayerItemId");

                    b.HasIndex("CurrentFuelPlayerItemId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ActionCommandGame.Model.PlayerItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("RemainingAttack")
                        .HasColumnType("int");

                    b.Property<int>("RemainingDefense")
                        .HasColumnType("int");

                    b.Property<int>("RemainingFuel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerItems");
                });

            modelBuilder.Entity("ActionCommandGame.Model.PositiveGameEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Probability")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PositiveGameEvents");
                });

            modelBuilder.Entity("ActionCommandGame.Model.Player", b =>
                {
                    b.HasOne("ActionCommandGame.Model.PlayerItem", "CurrentAttackPlayerItem")
                        .WithMany("AttackPlayers")
                        .HasForeignKey("CurrentAttackPlayerItemId");

                    b.HasOne("ActionCommandGame.Model.PlayerItem", "CurrentDefensePlayerItem")
                        .WithMany("DefensePlayers")
                        .HasForeignKey("CurrentDefensePlayerItemId");

                    b.HasOne("ActionCommandGame.Model.PlayerItem", "CurrentFuelPlayerItem")
                        .WithMany("FuelPlayers")
                        .HasForeignKey("CurrentFuelPlayerItemId");

                    b.Navigation("CurrentAttackPlayerItem");

                    b.Navigation("CurrentDefensePlayerItem");

                    b.Navigation("CurrentFuelPlayerItem");
                });

            modelBuilder.Entity("ActionCommandGame.Model.PlayerItem", b =>
                {
                    b.HasOne("ActionCommandGame.Model.Item", "Item")
                        .WithMany("PlayerItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ActionCommandGame.Model.Player", "Player")
                        .WithMany("Inventory")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ActionCommandGame.Model.Item", b =>
                {
                    b.Navigation("PlayerItems");
                });

            modelBuilder.Entity("ActionCommandGame.Model.Player", b =>
                {
                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("ActionCommandGame.Model.PlayerItem", b =>
                {
                    b.Navigation("AttackPlayers");

                    b.Navigation("DefensePlayers");

                    b.Navigation("FuelPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
