using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalBankAPI.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public long FromAccount { get; set; }
        public long ToAccount { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public string TransactionReason { get; set; }
        public bool TransactionState { get; set; }
        public bool? IsPending { get; set; }

        public virtual Account FromAccountNavigation { get; set; }
        public virtual Account ToAccountNavigation { get; set; }
    }
}
