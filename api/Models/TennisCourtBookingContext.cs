using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TennisCourtBooking.Models
{
    public partial class TennisCourtBookingContext : DbContext
    {
        public TennisCourtBookingContext()
        {
        }

        public TennisCourtBookingContext(DbContextOptions<TennisCourtBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bocking> Bockings { get; set; } = null!;
        public virtual DbSet<Court> Courts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=TennisCourtBooking;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.21-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Bocking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PRIMARY");

                entity.ToTable("Bocking");

                entity.HasIndex(e => e.CourtId, "courtId");

                entity.Property(e => e.BookingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("bookingId");

                entity.Property(e => e.CourtId)
                    .HasColumnType("int(11)")
                    .HasColumnName("courtId");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.EndTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("endTime");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .HasColumnName("lastname");

                entity.Property(e => e.StartTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("startTime");

                entity.Property(e => e.Type)
                    .HasColumnType("enum('BOOKED','BLOCKED')")
                    .HasColumnName("type");

                entity.HasOne(d => d.Court)
                    .WithMany(p => p.Bockings)
                    .HasForeignKey(d => d.CourtId)
                    .HasConstraintName("bocking_ibfk_1");
            });

            modelBuilder.Entity<Court>(entity =>
            {
                entity.ToTable("Court");

                entity.Property(e => e.CourtId)
                    .HasColumnType("int(11)")
                    .HasColumnName("courtId");

                entity.Property(e => e.Label)
                    .HasMaxLength(255)
                    .HasColumnName("label");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
