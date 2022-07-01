using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdminAPI.Models
{
    public partial class AdminsDBContext : DbContext
    {
        public AdminsDBContext()
        {
        }

        public AdminsDBContext(DbContextOptions<AdminsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Contribution> Contributions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AdminsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.AdminName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoggedInDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contribution>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Contribu__C1F8DC59ED57B11B");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.ChangedTime).HasColumnType("datetime");

                entity.Property(e => e.ChangesMade)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.ChangeMadeByNavigation)
                    .WithMany(p => p.Contributions)
                    .HasForeignKey(d => d.ChangeMadeBy)
                    .HasConstraintName("FK__Contribut__Chang__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
