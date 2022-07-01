using System;
using System.Collections.Generic;

#nullable disable

namespace TrainAPI.Models
{
    public partial class Train
    {
        public Train()
        {
            Reaches = new HashSet<Reach>();
            TrainStatuses = new HashSet<TrainStatus>();
        }

        public int TrainNumber { get; set; }
        public string TrainName { get; set; }
        public string TrainType { get; set; }
        public string Tsource { get; set; }
        public string Tdestination { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public int? AvailableSeats { get; set; }
        public int? NAc1Coaches { get; set; }
        public int? NAc2Coaches { get; set; }
        public int? NAc3Coaches { get; set; }
        public int? NSlCoaches { get; set; }
        public int? NSsCoaches { get; set; }
        public int? NGeneralCoaches { get; set; }
        public string RunsOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Station TdestinationNavigation { get; set; }
        public virtual Station TsourceNavigation { get; set; }
        public virtual ICollection<Reach> Reaches { get; set; }
        public virtual ICollection<TrainStatus> TrainStatuses { get; set; }
    }
}
