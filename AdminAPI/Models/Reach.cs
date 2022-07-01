using System;
using System.Collections.Generic;

#nullable disable

namespace AdminAPI.Models
{
    public partial class Reach
    {
        public int Id { get; set; }
        public int? TrainNumber { get; set; }
        public string StationCode { get; set; }
        public string ArrivalTime { get; set; }

        public virtual Station StationCodeNavigation { get; set; }
        public virtual Train TrainNumberNavigation { get; set; }
    }
}
