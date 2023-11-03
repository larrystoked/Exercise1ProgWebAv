﻿// <auto-generated />
using System;
using Jungle_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jungle_DataAccess.Migrations
{
    [DbContext(typeof(JungleDbContext))]
    partial class JungleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Jungle_Models.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Jungle_Models.Models.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("Jungle_Models.Models.Guide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Guides");
                });

            modelBuilder.Entity("Jungle_Models.Models.Travel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("GuideId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("TravelRecommendationId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("GuideId");

                    b.HasIndex("TravelRecommendationId")
                        .IsUnique();

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("Jungle_Models.Models.TravelRecommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DangerLevel")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.HasKey("Id");

                    b.ToTable("TravelRecommendations");
                });

            modelBuilder.Entity("Jungle_Models.Models.Destination", b =>
                {
                    b.HasOne("Jungle_Models.Models.Country", "Country")
                        .WithMany("Destinations")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Jungle_Models.Models.Travel", b =>
                {
                    b.HasOne("Jungle_Models.Models.Destination", null)
                        .WithMany("Travels")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jungle_Models.Models.Guide", "Guide")
                        .WithMany("Travels")
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jungle_Models.Models.TravelRecommendation", "TravelRecommendation")
                        .WithOne("Travel")
                        .HasForeignKey("Jungle_Models.Models.Travel", "TravelRecommendationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guide");

                    b.Navigation("TravelRecommendation");
                });

            modelBuilder.Entity("Jungle_Models.Models.Country", b =>
                {
                    b.Navigation("Destinations");
                });

            modelBuilder.Entity("Jungle_Models.Models.Destination", b =>
                {
                    b.Navigation("Travels");
                });

            modelBuilder.Entity("Jungle_Models.Models.Guide", b =>
                {
                    b.Navigation("Travels");
                });

            modelBuilder.Entity("Jungle_Models.Models.TravelRecommendation", b =>
                {
                    b.Navigation("Travel")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
