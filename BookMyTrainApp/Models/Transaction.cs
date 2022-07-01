using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyTrainApp.Models
{
    public class Transaction
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
    }
}
