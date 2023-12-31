﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace csharp_ef_webapi.Migrations
{
    [DbContext(typeof(AghanimsWagerContext))]
    [Migration("20231231054941_MatchDetails")]
    partial class MatchDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Kali")
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("csharp_ef_webapi.Models.BalanceLedger", b =>
                {
                    b.Property<long>("DiscordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("discord_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("DiscordId"));

                    b.Property<long>("Tokens")
                        .HasColumnType("bigint")
                        .HasColumnName("tokens");

                    b.HasKey("DiscordId");

                    b.ToTable("balance_ledger", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.BetStreak", b =>
                {
                    b.Property<string>("discordName")
                        .HasColumnType("text")
                        .HasColumnName("discord_name");

                    b.Property<long>("bet_streak")
                        .HasColumnType("bigint")
                        .HasColumnName("streak");

                    b.HasKey("discordName");

                    b.ToTable("bets_streaks", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.Bromance", b =>
                {
                    b.Property<string>("bro1Name")
                        .HasColumnType("text")
                        .HasColumnName("bro_1_name");

                    b.Property<string>("bro2Name")
                        .HasColumnType("text")
                        .HasColumnName("bro_2_name");

                    b.Property<int>("totalMatches")
                        .HasColumnType("integer")
                        .HasColumnName("total_matches");

                    b.Property<int>("totalWins")
                        .HasColumnType("integer")
                        .HasColumnName("total_wins");

                    b.HasKey("bro1Name", "bro2Name");

                    b.ToTable("bromance_last_60", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.DiscordIds", b =>
                {
                    b.Property<long>("DiscordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("discord_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("DiscordId"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint")
                        .HasColumnName("account_id");

                    b.Property<string>("DiscordName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("discord_name");

                    b.Property<long>("SteamId")
                        .HasColumnType("bigint")
                        .HasColumnName("steam_id");

                    b.HasKey("DiscordId");

                    b.ToTable("discord_ids", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.League", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("league_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("name")
                        .HasColumnType("text")
                        .HasColumnName("league_name");

                    b.HasKey("id");

                    b.ToTable("dota_leagues", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchDetail", b =>
                {
                    b.Property<long>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("match_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("MatchId"));

                    b.Property<int>("BarracksStatusDire")
                        .HasColumnType("integer")
                        .HasColumnName("barracks_status_dire");

                    b.Property<int>("BarracksStatusRadiant")
                        .HasColumnType("integer")
                        .HasColumnName("barracks_status_radiant");

                    b.Property<int>("Cluster")
                        .HasColumnType("integer")
                        .HasColumnName("cluster");

                    b.Property<int>("DireScore")
                        .HasColumnType("integer")
                        .HasColumnName("dire_score");

                    b.Property<int>("Duration")
                        .HasColumnType("integer")
                        .HasColumnName("duration");

                    b.Property<int>("Engine")
                        .HasColumnType("integer")
                        .HasColumnName("engine");

                    b.Property<int>("FirstBloodTime")
                        .HasColumnType("integer")
                        .HasColumnName("first_blood_time");

                    b.Property<int>("Flags")
                        .HasColumnType("integer")
                        .HasColumnName("flags");

                    b.Property<int>("GameMode")
                        .HasColumnType("integer")
                        .HasColumnName("game_mode");

                    b.Property<int>("HumanPlayers")
                        .HasColumnType("integer")
                        .HasColumnName("human_players");

                    b.Property<int>("LeagueId")
                        .HasColumnType("integer")
                        .HasColumnName("league_id");

                    b.Property<int>("LobbyType")
                        .HasColumnType("integer")
                        .HasColumnName("lobby_type");

                    b.Property<long>("MatchSeqNum")
                        .HasColumnType("bigint")
                        .HasColumnName("match_seq_num");

                    b.Property<int>("PreGameDuration")
                        .HasColumnType("integer")
                        .HasColumnName("pre_game_duration");

                    b.Property<int>("RadiantScore")
                        .HasColumnType("integer")
                        .HasColumnName("radiant_score");

                    b.Property<bool>("RadiantWin")
                        .HasColumnType("boolean")
                        .HasColumnName("radiant_win");

                    b.Property<long>("StartTime")
                        .HasColumnType("bigint")
                        .HasColumnName("start_time");

                    b.Property<int>("TowerStatusDire")
                        .HasColumnType("integer")
                        .HasColumnName("tower_status_dire");

                    b.Property<int>("TowerStatusRadiant")
                        .HasColumnType("integer")
                        .HasColumnName("tower_status_radiant");

                    b.HasKey("MatchId");

                    b.ToTable("dota_match_details", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchDetailsPicksBans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HeroId")
                        .HasColumnType("integer")
                        .HasColumnName("hero_id");

                    b.Property<bool>("IsPick")
                        .HasColumnType("boolean")
                        .HasColumnName("is_pick");

                    b.Property<long>("MatchId")
                        .HasColumnType("bigint")
                        .HasColumnName("match_id");

                    b.Property<int>("Order")
                        .HasColumnType("integer")
                        .HasColumnName("order");

                    b.Property<int>("Team")
                        .HasColumnType("integer")
                        .HasColumnName("team");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("dota_match_details_picks_bans", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchDetailsPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint")
                        .HasColumnName("account_id");

                    b.Property<int?>("AghanimsScepter")
                        .HasColumnType("integer")
                        .HasColumnName("aghanims_scepter");

                    b.Property<int?>("AghanimsShard")
                        .HasColumnType("integer")
                        .HasColumnName("aghanims_shard");

                    b.Property<int?>("Assists")
                        .HasColumnType("integer")
                        .HasColumnName("assists");

                    b.Property<int?>("Backpack0")
                        .HasColumnType("integer")
                        .HasColumnName("backpack_0");

                    b.Property<int?>("Backpack1")
                        .HasColumnType("integer")
                        .HasColumnName("backpack_1");

                    b.Property<int?>("Backpack2")
                        .HasColumnType("integer")
                        .HasColumnName("backpack_2");

                    b.Property<int?>("Deaths")
                        .HasColumnType("integer")
                        .HasColumnName("deaths");

                    b.Property<int?>("Denies")
                        .HasColumnType("integer")
                        .HasColumnName("denies");

                    b.Property<int?>("Gold")
                        .HasColumnType("integer")
                        .HasColumnName("gold");

                    b.Property<int?>("GoldPerMin")
                        .HasColumnType("integer")
                        .HasColumnName("gold_per_min");

                    b.Property<int?>("GoldSpent")
                        .HasColumnType("integer")
                        .HasColumnName("gold_spent");

                    b.Property<int?>("HeroDamage")
                        .HasColumnType("integer")
                        .HasColumnName("hero_damage");

                    b.Property<int?>("HeroHealing")
                        .HasColumnType("integer")
                        .HasColumnName("hero_healing");

                    b.Property<int>("HeroId")
                        .HasColumnType("integer")
                        .HasColumnName("hero_id");

                    b.Property<int?>("Item0")
                        .HasColumnType("integer")
                        .HasColumnName("item_0");

                    b.Property<int?>("Item1")
                        .HasColumnType("integer")
                        .HasColumnName("item_1");

                    b.Property<int?>("Item2")
                        .HasColumnType("integer")
                        .HasColumnName("item_2");

                    b.Property<int?>("Item3")
                        .HasColumnType("integer")
                        .HasColumnName("item_3");

                    b.Property<int?>("Item4")
                        .HasColumnType("integer")
                        .HasColumnName("item_4");

                    b.Property<int?>("Item5")
                        .HasColumnType("integer")
                        .HasColumnName("item_5");

                    b.Property<int?>("ItemNeutral")
                        .HasColumnType("integer")
                        .HasColumnName("item_neutral");

                    b.Property<int?>("Kills")
                        .HasColumnType("integer")
                        .HasColumnName("kills");

                    b.Property<int?>("LastHits")
                        .HasColumnType("integer")
                        .HasColumnName("last_hits");

                    b.Property<int?>("LeaverStatus")
                        .HasColumnType("integer")
                        .HasColumnName("leaver_status");

                    b.Property<int?>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<long>("MatchId")
                        .HasColumnType("bigint")
                        .HasColumnName("match_id");

                    b.Property<int?>("Moonshard")
                        .HasColumnType("integer")
                        .HasColumnName("moonshard");

                    b.Property<long?>("Networth")
                        .HasColumnType("bigint")
                        .HasColumnName("net_worth");

                    b.Property<int>("PlayerSlot")
                        .HasColumnType("integer")
                        .HasColumnName("player_slot");

                    b.Property<int?>("ScaledHeroDamage")
                        .HasColumnType("integer")
                        .HasColumnName("scaled_hero_damage");

                    b.Property<int?>("ScaledHeroHealing")
                        .HasColumnType("integer")
                        .HasColumnName("scaled_hero_healing");

                    b.Property<int?>("ScaledTowerDamage")
                        .HasColumnType("integer")
                        .HasColumnName("scaled_tower_damage");

                    b.Property<int?>("TeamNumber")
                        .HasColumnType("integer")
                        .HasColumnName("team_number");

                    b.Property<int?>("TeamSlot")
                        .HasColumnType("integer")
                        .HasColumnName("team_slot");

                    b.Property<int?>("TowerDamage")
                        .HasColumnType("integer")
                        .HasColumnName("tower_damage");

                    b.Property<int?>("XpPerMin")
                        .HasColumnType("integer")
                        .HasColumnName("xp_per_min");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("dota_match_details_players", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchDetailsPlayersAbilityUpgrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Ability")
                        .HasColumnType("integer")
                        .HasColumnName("ability");

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer")
                        .HasColumnName("player_id");

                    b.Property<int>("Time")
                        .HasColumnType("integer")
                        .HasColumnName("time");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("dota_match_details_players_ability_upgrades", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchHistory", b =>
                {
                    b.Property<long>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("match_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("MatchId"));

                    b.Property<long>("DireTeamId")
                        .HasColumnType("bigint")
                        .HasColumnName("dire_team_id");

                    b.Property<int>("LeagueId")
                        .HasColumnType("integer")
                        .HasColumnName("league_id");

                    b.Property<int>("LobbyType")
                        .HasColumnType("integer")
                        .HasColumnName("lobby_type");

                    b.Property<long>("MatchSeqNum")
                        .HasColumnType("bigint")
                        .HasColumnName("match_seq_num");

                    b.Property<long>("RadiantTeamId")
                        .HasColumnType("bigint")
                        .HasColumnName("radiant_team_id");

                    b.Property<int>("SeriesId")
                        .HasColumnType("integer")
                        .HasColumnName("series_id");

                    b.Property<int>("SeriesType")
                        .HasColumnType("integer")
                        .HasColumnName("series_type");

                    b.Property<long>("StartTime")
                        .HasColumnType("bigint")
                        .HasColumnName("start_time");

                    b.HasKey("MatchId");

                    b.HasIndex("LeagueId");

                    b.ToTable("dota_match_history", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchHistoryPlayer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint")
                        .HasColumnName("account_id");

                    b.Property<int>("HeroId")
                        .HasColumnType("integer")
                        .HasColumnName("hero_id");

                    b.Property<long>("MatchId")
                        .HasColumnType("bigint")
                        .HasColumnName("match_id");

                    b.Property<int>("PlayerSlot")
                        .HasColumnType("integer")
                        .HasColumnName("player_slot");

                    b.Property<int>("TeamNumber")
                        .HasColumnType("integer")
                        .HasColumnName("team_number");

                    b.Property<int>("TeamSlot")
                        .HasColumnType("integer")
                        .HasColumnName("team_slot");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("dota_match_history_players", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchStatus", b =>
                {
                    b.Property<long>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("match_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("MatchId"));

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("MatchId");

                    b.ToTable("match_status", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchStreak", b =>
                {
                    b.Property<string>("discordName")
                        .HasColumnType("text")
                        .HasColumnName("discord_name");

                    b.Property<long>("match_streak")
                        .HasColumnType("bigint")
                        .HasColumnName("streak");

                    b.HasKey("discordName");

                    b.ToTable("matches_streaks", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.PlayerMatchDetails", b =>
                {
                    b.Property<long>("MatchId")
                        .HasColumnType("bigint")
                        .HasColumnName("match_id");

                    b.Property<int>("PlayerSlot")
                        .HasColumnType("integer")
                        .HasColumnName("player_slot");

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint")
                        .HasColumnName("account_id");

                    b.Property<int?>("AghanimsScepter")
                        .HasColumnType("integer")
                        .HasColumnName("aghanims_scepter");

                    b.Property<int?>("AghanimsShard")
                        .HasColumnType("integer")
                        .HasColumnName("aghanims_shard");

                    b.Property<int?>("Assists")
                        .HasColumnType("integer")
                        .HasColumnName("assists");

                    b.Property<int?>("Backpack0")
                        .HasColumnType("integer")
                        .HasColumnName("backpack_0");

                    b.Property<int?>("Backpack1")
                        .HasColumnType("integer")
                        .HasColumnName("backpack_1");

                    b.Property<int?>("Backpack2")
                        .HasColumnType("integer")
                        .HasColumnName("backpack_2");

                    b.Property<int?>("Deaths")
                        .HasColumnType("integer")
                        .HasColumnName("deaths");

                    b.Property<int?>("Denies")
                        .HasColumnType("integer")
                        .HasColumnName("denies");

                    b.Property<int?>("Gold")
                        .HasColumnType("integer")
                        .HasColumnName("gold");

                    b.Property<int?>("GoldPerMin")
                        .HasColumnType("integer")
                        .HasColumnName("gold_per_min");

                    b.Property<int?>("GoldSpent")
                        .HasColumnType("integer")
                        .HasColumnName("gold_spent");

                    b.Property<int?>("HeroDamage")
                        .HasColumnType("integer")
                        .HasColumnName("hero_damage");

                    b.Property<int?>("HeroHealing")
                        .HasColumnType("integer")
                        .HasColumnName("hero_healing");

                    b.Property<int>("HeroId")
                        .HasColumnType("integer")
                        .HasColumnName("hero_id");

                    b.Property<int?>("Item0")
                        .HasColumnType("integer")
                        .HasColumnName("item_0");

                    b.Property<int?>("Item1")
                        .HasColumnType("integer")
                        .HasColumnName("item_1");

                    b.Property<int?>("Item2")
                        .HasColumnType("integer")
                        .HasColumnName("item_2");

                    b.Property<int?>("Item3")
                        .HasColumnType("integer")
                        .HasColumnName("item_3");

                    b.Property<int?>("Item4")
                        .HasColumnType("integer")
                        .HasColumnName("item_4");

                    b.Property<int?>("Item5")
                        .HasColumnType("integer")
                        .HasColumnName("item_5");

                    b.Property<int?>("ItemNeutral")
                        .HasColumnType("integer")
                        .HasColumnName("item_neutral");

                    b.Property<int?>("Kills")
                        .HasColumnType("integer")
                        .HasColumnName("kills");

                    b.Property<int?>("LastHits")
                        .HasColumnType("integer")
                        .HasColumnName("last_hits");

                    b.Property<int?>("LeaverStatus")
                        .HasColumnType("integer")
                        .HasColumnName("leaver_status");

                    b.Property<int?>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<int?>("Moonshard")
                        .HasColumnType("integer")
                        .HasColumnName("moonshard");

                    b.Property<long?>("Networth")
                        .HasColumnType("bigint")
                        .HasColumnName("net_worth");

                    b.Property<int?>("ScaledHeroDamage")
                        .HasColumnType("integer")
                        .HasColumnName("scaled_hero_damage");

                    b.Property<int?>("ScaledHeroHealing")
                        .HasColumnType("integer")
                        .HasColumnName("scaled_hero_healing");

                    b.Property<int?>("ScaledTowerDamage")
                        .HasColumnType("integer")
                        .HasColumnName("scaled_tower_damage");

                    b.Property<int?>("TeamNumber")
                        .HasColumnType("integer")
                        .HasColumnName("team_number");

                    b.Property<int?>("TeamSlot")
                        .HasColumnType("integer")
                        .HasColumnName("team_slot");

                    b.Property<int?>("TowerDamage")
                        .HasColumnType("integer")
                        .HasColumnName("tower_damage");

                    b.Property<int?>("XpPerMin")
                        .HasColumnType("integer")
                        .HasColumnName("xp_per_min");

                    b.HasKey("MatchId", "PlayerSlot");

                    b.ToTable("player_match_details", "Kali");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchDetailsPicksBans", b =>
                {
                    b.HasOne("csharp_ef_webapi.Models.MatchDetail", null)
                        .WithMany("PicksBans")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchDetailsPlayer", b =>
                {
                    b.HasOne("csharp_ef_webapi.Models.MatchDetail", null)
                        .WithMany("Players")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchDetailsPlayersAbilityUpgrade", b =>
                {
                    b.HasOne("csharp_ef_webapi.Models.MatchDetailsPlayer", null)
                        .WithMany("AbilityUpgrades")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchHistory", b =>
                {
                    b.HasOne("csharp_ef_webapi.Models.League", null)
                        .WithMany("leagueMatches")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchHistoryPlayer", b =>
                {
                    b.HasOne("csharp_ef_webapi.Models.MatchHistory", null)
                        .WithMany("Players")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.League", b =>
                {
                    b.Navigation("leagueMatches");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchDetail", b =>
                {
                    b.Navigation("PicksBans");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchDetailsPlayer", b =>
                {
                    b.Navigation("AbilityUpgrades");
                });

            modelBuilder.Entity("csharp_ef_webapi.Models.MatchHistory", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
