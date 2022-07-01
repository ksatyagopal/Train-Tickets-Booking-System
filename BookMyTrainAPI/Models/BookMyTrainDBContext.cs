using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookMyTrainAPI.Models
{
    public partial class BookMyTrainDBContext : DbContext
    {
        public BookMyTrainDBContext()
        {
        }

        public BookMyTrainDBContext(DbContextOptions<BookMyTrainDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MasterList> MasterLists { get; set; }
        public virtual DbSet<Pnr> Pnrs { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BookMyTrainDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<MasterList>(entity =>
            {
                entity.HasKey(e => e.Mid)
                    .HasName("PK__MasterLi__C797348A53767DF0");

                entity.ToTable("MasterList");

                entity.Property(e => e.Mid).HasColumnName("MID");

                entity.Property(e => e.AdharNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MasterLists)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__MasterLis__UserI__25869641");
            });

            modelBuilder.Entity<Pnr>(entity =>
            {
                entity.HasKey(e => e.Pnrnumber)
                    .HasName("PK__PNRs__A03A5D40AC59C244");

                entity.ToTable("PNRs");

                entity.Property(e => e.Pnrnumber).HasColumnName("PNRNumber");

                entity.Property(e => e.BoardingStation)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FromStation)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JourneyDate).HasColumnType("date");

                entity.Property(e => e.JourneyEndTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JourneyStartTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ToStation)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TotalFare).HasColumnType("money");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.TypeOfCoach)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Pnrs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__PNRs__UserID__36B12243");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.Coach)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PassengerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pnrnumber).HasColumnName("PNRNumber");

                entity.Property(e => e.ReservationStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.PnrnumberNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.Pnrnumber)
                    .HasConstraintName("FK__Tickets__PNRNumb__398D8EEE");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AdharNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastLoggedInDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MailID");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SecQuesAnswer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQuestion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
