using System;
using System.Collections.Generic;

#nullable disable

namespace BookMyTrainAPI.Models
{
    public partial class User
    {
        public User()
        {
            MasterLists = new HashSet<MasterList>();
            Pnrs = new HashSet<Pnr>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdharNumber { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Mobile { get; set; }
        public string MailId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecQuesAnswer { get; set; }
        public string Password { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastLoggedInDate { get; set; }

        public virtual ICollection<MasterList> MasterLists { get; set; }
        public virtual ICollection<Pnr> Pnrs { get; set; }
    }
}
