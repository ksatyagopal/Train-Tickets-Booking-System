using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DigitalBankWebAppMVC.Models
{
    public partial class AccountLogin
    {
        [DisplayName("Email ID")]
        public string UserName { get; set; }
        [DisplayName("Account Number")]
        public long? AccountNumber { get; set; }
        [DisplayName("Security Question")]
        public string SecurityQuestion { get; set; }
        [DisplayName("Security Question Answer")]
        public string SecurityQanswer { get; set; }
        public DateTime? LastLoggedInDate { get; set; }
        [DisplayName("Password")]
        [Required]
        [MinLength(8, ErrorMessage ="Password must have atleast 8 characters")]
        public string Password { get; set; }

        public virtual Account AccountNumberNavigation { get; set; }
    }
}
