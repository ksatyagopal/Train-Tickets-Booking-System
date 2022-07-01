using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BookMyTrainApp.Models
{
    public partial class User
    {
        public User()
        {
            MasterLists = new HashSet<MasterList>();
            Pnrs = new HashSet<Pnr>();
        }

        public int UserId { get; set; }
        [DisplayName("First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Aadhaar Number")]
        public string AdharNumber { get; set; }
        [DisplayName("Gender")]
        public string Gender { get; set; }
        [DisplayName("Age")]
        [Range(minimum:18, maximum:100, ErrorMessage ="Age should lie in between 18 and 100")]
        public int? Age { get; set; }
        [DisplayName("Mobile Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage ="Not a valid Mobile Number")]
        public string Mobile { get; set; }
        [DisplayName("Mail ID")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid Email")]
        public string MailId { get; set; }
        [DisplayName("City")]
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        [DisplayName("Security Question")]
        public string SecurityQuestion { get; set; }
        [DisplayName("Security Question Answer")]
        public string SecQuesAnswer { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool? IsDeleted { get; set; }
        [DisplayName("Last Logged In Date")]
        public DateTime? LastLoggedInDate { get; set; }

        public virtual ICollection<MasterList> MasterLists { get; set; }
        public virtual ICollection<Pnr> Pnrs { get; set; }
    }
}
