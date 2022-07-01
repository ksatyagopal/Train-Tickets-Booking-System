using System;
using System.Collections.Generic;

#nullable disable

namespace BookMyTrainAPI.Models
{
    public partial class StationDistance
    {
        public int Id { get; set; }
        public string StationA { get; set; }
        public string StationB { get; set; }
        public int? Distance { get; set; }

        public virtual Station StationANavigation { get; set; }
        public virtual Station StationBNavigation { get; set; }
    }
}
