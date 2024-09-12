﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoochyDexApi;

#nullable disable

namespace PoochyDexApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PoochyDexApi.Entities.FormData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FormName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FormsId")
                        .HasColumnType("int");

                    b.Property<int?>("HomeSpriteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormsId");

                    b.HasIndex("HomeSpriteId");

                    b.ToTable("FormData");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.Forms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PokemonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Forms");
                });

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

            modelBuilder.Entity("PoochyDexApi.Entities.HomeSprites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HomeUrlShinySprite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeUrlSprite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpritesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpritesId");

                    b.ToTable("HomeSprites");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("AltForms")
                        .HasColumnType("bit");

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

                    b.Property<int>("VideoGameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VideoGameId");

                    b.ToTable("ReleaseDate");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.Sprites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PokemonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Sprites");
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

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

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

            modelBuilder.Entity("PoochyDexApi.Entities.FormData", b =>
                {
                    b.HasOne("PoochyDexApi.Entities.Forms", null)
                        .WithMany("PokemonForms")
                        .HasForeignKey("FormsId");

                    b.HasOne("PoochyDexApi.Entities.HomeSprites", "HomeSprite")
                        .WithMany()
                        .HasForeignKey("HomeSpriteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("HomeSprite");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.Forms", b =>
                {
                    b.HasOne("PoochyDexApi.Entities.Pokemon", "Pokemon")
                        .WithMany("Forms")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.HomeSprites", b =>
                {
                    b.HasOne("PoochyDexApi.Entities.Sprites", null)
                        .WithMany("HomeSprites")
                        .HasForeignKey("SpritesId");
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
                    b.HasOne("PoochyDexApi.Entities.VideoGames", "VideoGame")
                        .WithMany("ReleaseDates")
                        .HasForeignKey("VideoGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VideoGame");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.Sprites", b =>
                {
                    b.HasOne("PoochyDexApi.Entities.Pokemon", "Pokemon")
                        .WithMany("Sprites")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Pokemon");
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

            modelBuilder.Entity("PoochyDexApi.Entities.Forms", b =>
                {
                    b.Navigation("PokemonForms");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.Generation", b =>
                {
                    b.Navigation("VideoGames");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.Pokemon", b =>
                {
                    b.Navigation("Forms");

                    b.Navigation("Sprites");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.Sprites", b =>
                {
                    b.Navigation("HomeSprites");
                });

            modelBuilder.Entity("PoochyDexApi.Entities.VideoGames", b =>
                {
                    b.Navigation("ReleaseDates");
                });
#pragma warning restore 612, 618
        }
    }
}
