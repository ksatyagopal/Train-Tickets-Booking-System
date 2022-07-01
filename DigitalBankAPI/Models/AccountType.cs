using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalBankAPI.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        public int TypeNumber { get; set; }
        public string TypeName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
