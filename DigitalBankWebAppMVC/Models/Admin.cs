using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalBankWebAppMVC.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Accounts = new HashSet<Account>();
            CardRequests = new HashSet<CardRequest>();
            LoanRequests = new HashSet<LoanRequest>();
        }

        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsSuperAdmin { get; set; }
        public DateTime? LastLoggedInDate { get; set; }
        public bool? IsActive { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<CardRequest> CardRequests { get; set; }
        public virtual ICollection<LoanRequest> LoanRequests { get; set; }
    }
}
