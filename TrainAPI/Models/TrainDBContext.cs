using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TrainAPI.Models
{
    public partial class TrainDBContext : DbContext
    {
        public TrainDBContext()
        {
        }

        public TrainDBContext(DbContextOptions<TrainDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fare> Fares { get; set; }
        public virtual DbSet<Reach> Reaches { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<StationDistance> StationDistances { get; set; }
        public virtual DbSet<Train> Trains { get; set; }
        public virtual DbSet<TrainStatus> TrainStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TrainDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Fare>(entity =>
            {
                entity.HasKey(e => e.TypeOfCoach)
                    .HasName("PK__Fares__A1063D52FA3076BD");

                entity.Property(e => e.TypeOfCoach)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fare1)
                    .HasColumnType("money")
                    .HasColumnName("Fare");
            });

            modelBuilder.Entity<Reach>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArrivalTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StationCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.StationCodeNavigation)
                    .WithMany(p => p.Reaches)
                    .HasForeignKey(d => d.StationCode)
                    .HasConstraintName("FK__Reaches__Station__37A5467C");

                entity.HasOne(d => d.TrainNumberNavigation)
                    .WithMany(p => p.Reaches)
                    .HasForeignKey(d => d.TrainNumber)
                    .HasConstraintName("FK__Reaches__TrainNu__36B12243");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasKey(e => e.StationCode)
                    .HasName("PK__Stations__D3885619C05BB385");

                entity.Property(e => e.StationCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StationLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StationDistance>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StationA)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StationB)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.StationANavigation)
                    .WithMany(p => p.StationDistanceStationANavigations)
                    .HasForeignKey(d => d.StationA)
                    .HasConstraintName("FK__StationDi__Stati__31EC6D26");

                entity.HasOne(d => d.StationBNavigation)
                    .WithMany(p => p.StationDistanceStationBNavigations)
                    .HasForeignKey(d => d.StationB)
                    .HasConstraintName("FK__StationDi__Stati__32E0915F");
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.HasKey(e => e.TrainNumber)
                    .HasName("PK__Trains__10C2CD2E8F3054C1");

                entity.Property(e => e.TrainNumber).ValueGeneratedNever();

                entity.Property(e => e.ArrivalTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NAc1Coaches).HasColumnName("nAc1Coaches");

                entity.Property(e => e.NAc2Coaches).HasColumnName("nAc2Coaches");

                entity.Property(e => e.NAc3Coaches).HasColumnName("nAc3Coaches");

                entity.Property(e => e.NGeneralCoaches).HasColumnName("nGeneralCoaches");

                entity.Property(e => e.NSlCoaches).HasColumnName("nSlCoaches");

                entity.Property(e => e.NSsCoaches).HasColumnName("nSsCoaches");

                entity.Property(e => e.RunsOn)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Tdestination)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TDestination");

                entity.Property(e => e.TrainName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrainType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tsource)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TSource");

                entity.HasOne(d => d.TdestinationNavigation)
                    .WithMany(p => p.TrainTdestinationNavigations)
                    .HasForeignKey(d => d.Tdestination)
                    .HasConstraintName("FK__Trains__TDestina__267ABA7A");

                entity.HasOne(d => d.TsourceNavigation)
                    .WithMany(p => p.TrainTsourceNavigations)
                    .HasForeignKey(d => d.Tsource)
                    .HasConstraintName("FK__Trains__TSource__25869641");
            });

            modelBuilder.Entity<TrainStatus>(entity =>
            {
                entity.HasKey(e => e.Tsid)
                    .HasName("PK__TrainSta__82B89D847D70256C");

                entity.ToTable("TrainStatus");

                entity.Property(e => e.Tsid)
                    .ValueGeneratedNever()
                    .HasColumnName("TSid");

                entity.Property(e => e.Doj)
                    .HasColumnType("date")
                    .HasColumnName("DOJ");

                entity.HasOne(d => d.TrainNumberNavigation)
                    .WithMany(p => p.TrainStatuses)
                    .HasForeignKey(d => d.TrainNumber)
                    .HasConstraintName("FK__TrainStat__Train__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
