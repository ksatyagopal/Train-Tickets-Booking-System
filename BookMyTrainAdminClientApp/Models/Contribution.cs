using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace BookMyTrainAdminClientApp.Models
{
    public partial class Contribution
    {
        public Contribution() { }
        public Contribution(int cmb, string r, string c, DateTime dt, string reason)
        {
            ChangeMadeBy = cmb;
            Reference = r;
            ChangesMade = c;
            ChangedTime = dt;
            Reason = reason;
        }

        [DisplayName("Contribution ID")]
        public int Cid { get; set; }
        [DisplayName("Change Made By")]
        public int? ChangeMadeBy { get; set; }
        public string Reference { get; set; }
        [DisplayName("Changes Made")]
        public string ChangesMade { get; set; }
        [DisplayName("Changes Made On")]
        public DateTime? ChangedTime { get; set; }
        public string Reason { get; set; }

        public virtual Admin ChangeMadeByNavigation { get; set; }
    }
}
