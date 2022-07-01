using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalBankAPI.Models
{
    public partial class CardRequest
    {
        public int RequestId { get; set; }
        public long RequestedByAccNumber { get; set; }
        public long? ReferenceNumber { get; set; }
        public DateTime? RequestedDate { get; set; }
        public string RequestStatus { get; set; }
        public int? RequestApprovedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Card ReferenceNumberNavigation { get; set; }
        public virtual Admin RequestApprovedByNavigation { get; set; }
        public virtual Account RequestedByAccNumberNavigation { get; set; }
    }
}
