using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DigitalBankWebAppMVC.Models
{
    public partial class DigitalBankContext : DbContext
    {
        public DigitalBankContext()
        {
        }

        public DigitalBankContext(DbContextOptions<DigitalBankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountLogin> AccountLogins { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<CardRequest> CardRequests { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanRequest> LoanRequests { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DigitalBank;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("PK__Accounts__BE2ACD6E71B3C471");

                entity.HasIndex(e => e.Mobile, "UQ__Accounts__6FAE078295D827B5")
                    .IsUnique();

                entity.Property(e => e.AccHolderName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedDate).HasColumnType("date");

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountTypeNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accounts__Accoun__286302EC");

                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ApprovedBy)
                    .HasConstraintName("FK__Accounts__Approv__2A4B4B5E");
            });

            modelBuilder.Entity<AccountLogin>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__AccountL__C9F28457C4F93032");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoggedInDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityQanswer)
                    .IsRequired()
                    .HasColumnName("SecurityQAnswer");

                entity.Property(e => e.SecurityQuestion).IsRequired();

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.AccountLogins)
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("FK__AccountLo__Accou__46E78A0C");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasKey(e => e.TypeNumber)
                    .HasName("PK__AccountT__113BC273F7B798F6");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId).HasColumnName("adminId");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoggedInDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.CardNumber)
                    .HasName("PK__Cards__A4E9FFE8D19AF3E3");

                entity.Property(e => e.CardAppliedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CardApprovedDate).HasColumnType("date");

                entity.Property(e => e.CradExpiryDate).HasColumnType("date");

                entity.Property(e => e.DeliveryAddress).IsRequired();

                entity.HasOne(d => d.CardHolderAccNumberNavigation)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.CardHolderAccNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cards__CardHolde__35BCFE0A");
            });

            modelBuilder.Entity<CardRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__CardRequ__33A8519A6280CD8D");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.RequestStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Not Approved')");

                entity.Property(e => e.RequestedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ReferenceNumberNavigation)
                    .WithMany(p => p.CardRequests)
                    .HasForeignKey(d => d.ReferenceNumber)
                    .HasConstraintName("FK__CardReque__Refer__3A81B327");

                entity.HasOne(d => d.RequestApprovedByNavigation)
                    .WithMany(p => p.CardRequests)
                    .HasForeignKey(d => d.RequestApprovedBy)
                    .HasConstraintName("FK__CardReque__Reque__3D5E1FD2");

                entity.HasOne(d => d.RequestedByAccNumberNavigation)
                    .WithMany(p => p.CardRequests)
                    .HasForeignKey(d => d.RequestedByAccNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CardReque__Reque__398D8EEE");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.LoanAmount).HasColumnType("money");

                entity.Property(e => e.LoanTakenDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OptedByAccNumberNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.OptedByAccNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loans__OptedByAc__31EC6D26");
            });

            modelBuilder.Entity<LoanRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__LoanRequ__33A8519ABA9C768F");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.RequestStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Not Approved')");

                entity.Property(e => e.RequestedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ReferenceNumberNavigation)
                    .WithMany(p => p.LoanRequests)
                    .HasForeignKey(d => d.ReferenceNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LoanReque__Refer__412EB0B6");

                entity.HasOne(d => d.RequestApprovedByNavigation)
                    .WithMany(p => p.LoanRequests)
                    .HasForeignKey(d => d.RequestApprovedBy)
                    .HasConstraintName("FK__LoanReque__Reque__440B1D61");

                entity.HasOne(d => d.RequestedByAccNumberNavigation)
                    .WithMany(p => p.LoanRequests)
                    .HasForeignKey(d => d.RequestedByAccNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LoanReque__Reque__403A8C7D");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.TransactionAmount).HasColumnType("money");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransactionReason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.FromAccountNavigation)
                    .WithMany(p => p.TransactionFromAccountNavigations)
                    .HasForeignKey(d => d.FromAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__FromA__49C3F6B7");

                entity.HasOne(d => d.ToAccountNavigation)
                    .WithMany(p => p.TransactionToAccountNavigations)
                    .HasForeignKey(d => d.ToAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__ToAcc__4AB81AF0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
