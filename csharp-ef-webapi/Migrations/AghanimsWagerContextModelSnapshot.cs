﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace csharp_ef_webapi.Migrations
{
    [DbContext(typeof(AghanimsWagerContext))]
    partial class AghanimsWagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
#pragma warning restore 612, 618
        }
    }
}
