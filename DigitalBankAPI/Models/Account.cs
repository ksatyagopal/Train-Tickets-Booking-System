using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalBankAPI.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountLogins = new HashSet<AccountLogin>();
            CardRequests = new HashSet<CardRequest>();
            Cards = new HashSet<Card>();
            LoanRequests = new HashSet<LoanRequest>();
            Loans = new HashSet<Loan>();
            TransactionFromAccountNavigations = new HashSet<Transaction>();
            TransactionToAccountNavigations = new HashSet<Transaction>();
        }

        public long AccountNumber { get; set; }
        public string AccHolderName { get; set; }
        public string Mobile { get; set; }
        public DateTime Dob { get; set; }
        public string ResidenceAddress { get; set; }
        public int AccountType { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool IsActive { get; set; }
        public decimal? Balance { get; set; }

        public virtual AccountType AccountTypeNavigation { get; set; }
        public virtual Admin ApprovedByNavigation { get; set; }
        public virtual ICollection<AccountLogin> AccountLogins { get; set; }
        public virtual ICollection<CardRequest> CardRequests { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<LoanRequest> LoanRequests { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Transaction> TransactionFromAccountNavigations { get; set; }
        public virtual ICollection<Transaction> TransactionToAccountNavigations { get; set; }
    }
}
