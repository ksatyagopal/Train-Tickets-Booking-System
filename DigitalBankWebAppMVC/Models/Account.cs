using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DigitalBankWebAppMVC.Models
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

        [DisplayName("Account Number")]
        public long AccountNumber { get; set; }

        [DisplayName("Account Holder Name")]
        public string AccHolderName { get; set; }

        [DisplayName("Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        [DisplayName("Residence Address")]
        public string ResidenceAddress { get; set; }
        [DisplayName("Account Type")]
        public int AccountType { get; set; }

        [DisplayName("Date of Creation")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        [DisplayName("Approved By")]
        public int? ApprovedBy { get; set; }
        [DisplayName("Date of Approval")]
        [DataType(DataType.Date)]
        public DateTime? ApprovedDate { get; set; }
        public bool IsActive { get; set; }
        [DisplayName("Balance")]
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
