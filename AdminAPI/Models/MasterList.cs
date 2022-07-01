using System;
using System.Collections.Generic;

#nullable disable

namespace AdminAPI.Models
{
    public partial class MasterList
    {
        public int Mid { get; set; }
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdharNumber { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual User User { get; set; }
    }
}
