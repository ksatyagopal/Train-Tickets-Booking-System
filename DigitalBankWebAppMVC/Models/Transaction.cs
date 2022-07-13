using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace DigitalBankWebAppMVC.Models
{
    public partial class Transaction
    {
        [DisplayName("Transaction ID")]
        public int TransactionId { get; set; }
        [DisplayName("From Account")]
        public long FromAccount { get; set; }
        [DisplayName("To Account")]
        public long ToAccount { get; set; }
        [DisplayName("Transaction Date")]
        public DateTime? TransactionDate { get; set; }
        [DisplayName("Amount")]
        public decimal TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        [DisplayName("Reason")]
        public string TransactionReason { get; set; }
        public bool TransactionState { get; set; }
        public bool? IsPending { get; set; }
        [DisplayName("From")]
        public virtual Account FromAccountNavigation { get; set; }
        [DisplayName("To")]
        public virtual Account ToAccountNavigation { get; set; }
    }
}
