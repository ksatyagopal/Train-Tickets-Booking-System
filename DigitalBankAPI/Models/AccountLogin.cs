using System;
using System.Collections.Generic;

#nullable disable

namespace DigitalBankAPI.Models
{
    public partial class AccountLogin
    {
        public string UserName { get; set; }
        public long? AccountNumber { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityQanswer { get; set; }
        public DateTime? LastLoggedInDate { get; set; }
        public string Password { get; set; }

        public virtual Account AccountNumberNavigation { get; set; }
    }
}
