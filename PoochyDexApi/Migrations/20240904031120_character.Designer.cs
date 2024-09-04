﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoochyDexApi;

#nullable disable

namespace PoochyDexApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240904031120_character")]
    partial class character
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PoochyDexApi.Entities.Generation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generation");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("generationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("generationId");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenerationId")
                        .HasColumnType("int");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenerationId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.ReleaseDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Console")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VideoGamesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VideoGamesId");

                    b.ToTable("ReleaseDate");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.VideoGames", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DevelopedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Games")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Platforms")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Players")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublishedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlFrontPage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("generationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("generationId");

                    b.ToTable("VideoGames");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.Pokemon", b =>
                {
                    b.HasOne("PoochyDexApi.Entities.Generation", "Generation")
                        .WithMany()
                        .HasForeignKey("generationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generation");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.Region", b =>
                {
                    b.HasOne("PoochyDexApi.Entities.Generation", "Generation")
                        .WithMany()
                        .HasForeignKey("GenerationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generation");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.ReleaseDate", b =>
                {
                    b.HasOne("PoochyDexApi.Entities.VideoGames", null)
                        .WithMany("ReleaseDates")
                        .HasForeignKey("VideoGamesId");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.VideoGames", b =>
                {
                    b.HasOne("PoochyDexApi.Entities.Generation", "Generation")
                        .WithMany("VideoGames")
                        .HasForeignKey("generationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generation");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.Generation", b =>
                {
                    b.Navigation("VideoGames");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.VideoGames", b =>
                {
                    b.Navigation("ReleaseDates");
                });
#pragma warning restore 612, 618
        }
    }
}
