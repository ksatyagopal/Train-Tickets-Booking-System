using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalBankAPI.Models
{
    public partial class LoanRequest
    {
        public int RequestId { get; set; }
        public long RequestedByAccNumber { get; set; }
        public int ReferenceNumber { get; set; }
        public DateTime? RequestedDate { get; set; }
        public string RequestStatus { get; set; }
        public int? RequestApprovedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Loan ReferenceNumberNavigation { get; set; }
        public virtual Admin RequestApprovedByNavigation { get; set; }
        public virtual Account RequestedByAccNumberNavigation { get; set; }
    }
}
