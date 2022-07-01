using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalBankAPI.Models
{
    public partial class Loan
    {
        public Loan()
        {
            LoanRequests = new HashSet<LoanRequest>();
        }

        public int LoanId { get; set; }
        public long OptedByAccNumber { get; set; }
        public decimal LoanAmount { get; set; }
        public double Interest { get; set; }
        public int LoanDurationInMonths { get; set; }
        public DateTime? LoanTakenDate { get; set; }
        public bool? LoanStatus { get; set; }
        public bool? IsActive { get; set; }

        public virtual Account OptedByAccNumberNavigation { get; set; }
        public virtual ICollection<LoanRequest> LoanRequests { get; set; }
    }
}
