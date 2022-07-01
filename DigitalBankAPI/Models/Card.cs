using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalBankAPI.Models
{
    public partial class Card
    {
        public Card()
        {
            CardRequests = new HashSet<CardRequest>();
        }

        public long CardNumber { get; set; }
        public long CardHolderAccNumber { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime? CardAppliedDate { get; set; }
        public DateTime? CardApprovedDate { get; set; }
        public DateTime? CradExpiryDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Account CardHolderAccNumberNavigation { get; set; }
        public virtual ICollection<CardRequest> CardRequests { get; set; }
    }
}
