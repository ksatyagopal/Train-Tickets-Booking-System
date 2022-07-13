using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace DigitalBankWebAppMVC.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }
        [DisplayName("Type Number")]
        public int TypeNumber { get; set; }
        [DisplayName("Account Type")]
        public string TypeName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
