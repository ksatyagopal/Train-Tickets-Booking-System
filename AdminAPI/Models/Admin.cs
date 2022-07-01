using System;
using System.Collections.Generic;

#nullable disable

namespace AdminAPI.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Contributions = new HashSet<Contribution>();
        }

        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string AdminName { get; set; }
        public bool? IsSuperAdmin { get; set; }
        public DateTime? LastLoggedInDate { get; set; }
        public bool? IsActive { get; set; }
        public string Password { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsLocked { get; set; }
        public int? UnSuccessfulAttempts { get; set; }

        public virtual ICollection<Contribution> Contributions { get; set; }
    }
}
