﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieLibrary;

namespace MovieLibrary.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20191216194646_NewStep")]
    partial class NewStep
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieLibrary.MovieDetails", b =>
                {
                    b.Property<int>("TrackNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Availability");

                    b.Property<double>("BuyAmount");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Language");

                    b.Property<string>("MovieName")
                        .IsRequired();

                    b.Property<double>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<int>("ReleasedYear");

                    b.Property<double>("RentAmount");

                    b.Property<int>("Views");

                    b.HasKey("TrackNumber")
                        .HasName("PK_TrackNumber");

                    b.ToTable("MoviesDetails");
                });

            modelBuilder.Entity("MovieLibrary.MovieRental", b =>
                {
                    b.Property<int>("RentalID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<int>("Language");

                    b.Property<string>("MovieName")
                        .IsRequired();

                    b.Property<int>("ReleasedYear");

                    b.Property<int>("RentalType");

                    b.Property<int>("TrackNumber");

                    b.HasKey("RentalID")
                        .HasName("PK_RentalID");

                    b.HasIndex("TrackNumber");

                    b.ToTable("MoviesRental");
                });

            modelBuilder.Entity("MovieLibrary.MovieRental", b =>
                {
                    b.HasOne("MovieLibrary.MovieDetails", "MovieDetails")
                        .WithMany()
                        .HasForeignKey("TrackNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
