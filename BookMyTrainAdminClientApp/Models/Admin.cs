using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BookMyTrainAdminClientApp.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Contributions = new HashSet<Contribution>();
        }

        [DisplayName("Admin ID")]
        public int AdminId { get; set; }
        [DisplayName("Email ID")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [DisplayName("Admin Name")]
        public string AdminName { get; set; }
        [DisplayName("Is Super Admin")]
        public bool IsSuperAdmin { get; set; }
        [DisplayName("Last Logged On")]
        public DateTime? LastLoggedInDate { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        public string Password { get; set; }
        [DisplayName("Is Deleted")]
        public bool IsDeleted { get; set; }
        [DisplayName("IS Locked")]
        public bool IsLocked { get; set; }
        [DisplayName("UnSuccessful Login Attempts")]
        public int? UnSuccessfulAttempts { get; set; }

        public virtual ICollection<Contribution> Contributions { get; set; }
    }
}
