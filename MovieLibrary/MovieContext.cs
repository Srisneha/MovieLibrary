using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLibrary
{
    class MovieContext : DbContext

    {

        public DbSet<MovieDetails> MoviesDetails { get; set; }
        public DbSet<MovieRental> MoviesRental { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Movie 2019;Integrated Security=True;Connect Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDetails>(entity =>
                {
                    entity.HasKey(m => m.TrackNumber)
                    .HasName("PK_TrackNumber");

                    entity.Property(m => m.TrackNumber)
                    .ValueGeneratedOnAdd();

                    entity.Property(m => m.MovieName)
                    .IsRequired();

                    entity.Property(m => m.Language)
                    .IsRequired();

                    entity.Property(m => m.ReleasedYear)
                    .IsRequired();

                    entity.Property(m => m.Rating)
                    .HasDefaultValue();

                    entity.ToTable("MoviesDetails");
                });

            modelBuilder.Entity<MovieRental>(entity =>

            {
                entity.HasKey(r => r.RentalID).HasName("PK_RentalID");

                entity.Property(r => r.MovieName).IsRequired();
                entity.Property(r => r.Language).IsRequired();
                entity.Property(r => r.RentalType).IsRequired();
                entity.Property(r => r.ReleasedYear).IsRequired();

                entity.HasOne(r => r.MovieDetails)
                .WithMany()
                .HasForeignKey(r => r.TrackNumber);

            }
            );


        }



       
    }

}
