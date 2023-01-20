using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TennisBookingApi.DbRepo
{
  public partial class ScottDbContext : DbContext
  {
    public ScottDbContext()
    {
    }

    public ScottDbContext(DbContextOptions<ScottDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }
    public virtual DbSet<Court> Courts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //optionsBuilder.UseMySQL("server=localhost;user id=root;password=;database=TennisCourtBooking");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Booking>(entity =>
      {
        entity.HasKey(e => e.BookingId)
                  .HasName("PRIMARY");

        entity.ToTable("Booking", "tenniscourtbooking");

        entity.HasIndex(e => e.CourtId, "courtId");

        entity.Property(e => e.BookingId)
                  .HasColumnType("int(11)")
                  .HasColumnName("bookingId");

        entity.Property(e => e.CourtId)
                  .HasColumnType("int(11)")
                  .HasColumnName("courtId")
                  .HasDefaultValueSql("'NULL'");

        entity.Property(e => e.Date)
                  .HasColumnType("date")
                  .HasColumnName("date")
                  .HasDefaultValueSql("'NULL'");

        entity.Property(e => e.EndTime)
                  .HasColumnType("int(11)")
                  .HasColumnName("endTime")
                  .HasDefaultValueSql("'NULL'");

        entity.Property(e => e.Firstname)
                  .HasMaxLength(255)
                  .HasColumnName("firstname")
                  .HasDefaultValueSql("'NULL'");

        entity.Property(e => e.Lastname)
                  .HasMaxLength(255)
                  .HasColumnName("lastname")
                  .HasDefaultValueSql("'NULL'");

        entity.Property(e => e.StartTime)
                  .HasColumnType("int(11)")
                  .HasColumnName("startTime")
                  .HasDefaultValueSql("'NULL'");

        entity.Property(e => e.Type)
                  .HasColumnType("enum('BOOKED','BLOCKED')")
                  .HasColumnName("type")
                  .HasDefaultValueSql("'NULL'");

        entity.HasOne(d => d.Court)
                  .WithMany(p => p.Bookings)
                  .HasForeignKey(d => d.CourtId)
                  .HasConstraintName("Booking_ibfk_1");
      });

      modelBuilder.Entity<Court>(entity =>
      {
        entity.ToTable("Court", "tenniscourtbooking");

        entity.Property(e => e.CourtId)
                  .HasColumnType("int(11)")
                  .HasColumnName("courtId");

        entity.Property(e => e.Label)
                  .HasMaxLength(255)
                  .HasColumnName("label")
                  .HasDefaultValueSql("'NULL'");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
