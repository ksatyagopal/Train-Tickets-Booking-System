using System;
using System.Collections.Generic;

#nullable disable

namespace BookMyTrainApp.Models
{
    public partial class Account
    {
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

        
    }
}
