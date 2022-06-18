using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Deltax.Entities
{
    public partial class DeltaDBContext : DbContext
    {
        public DeltaDBContext()
        {
        }

        public DeltaDBContext(DbContextOptions<DeltaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Master> Masters { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<MovieDetail> MovieDetails { get; set; } = null!;
        public virtual DbSet<Producer> Producers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=database-1.c1f6toreiojm.ap-south-1.rds.amazonaws.com;Database=DeltaDB;User Id=admin;Password=developer");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.ActorId).HasColumnName("ActorID");

                entity.Property(e => e.ActorName).HasMaxLength(50);

                entity.Property(e => e.Bio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");
            });

            modelBuilder.Entity<Master>(entity =>
            {
                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.MasterName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MasterType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.MovieName).HasMaxLength(50);

                entity.Property(e => e.ProducerId).HasColumnName("ProducerID");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ProducerId)
                    .HasConstraintName("FK_Movies_Producer");
            });

            modelBuilder.Entity<MovieDetail>(entity =>
            {
                entity.HasKey(e => e.MovieDetailsId)
                    .HasName("PK__MovieDet__66FA4D66B63FB18D");

                entity.Property(e => e.MovieDetailsId).HasColumnName("MovieDetailsID");

                entity.Property(e => e.ActorId).HasColumnName("ActorID");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.MovieDetails)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK_MovieDetails_Actors");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieDetails)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_MovieDetails_Movies");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.Property(e => e.ProducerId).HasColumnName("ProducerID");

                entity.Property(e => e.Bio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Comapny)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.ProducerName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
