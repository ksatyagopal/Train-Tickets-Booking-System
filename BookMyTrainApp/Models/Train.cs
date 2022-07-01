using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BookMyTrainApp.Models
{
    public partial class Train
    {
        public Train()
        {
            Reaches = new HashSet<Reach>();
            TrainStatuses = new HashSet<TrainStatus>();
        }
        [DisplayName("Train Number")]
        public int TrainNumber { get; set; }
        [DisplayName("Train Name")]
        public string TrainName { get; set; }
        [DisplayName("Source Station")]
        public string Tsource { get; set; }
        [DisplayName("Destination Station")]
        public string Tdestination { get; set; }
        [DisplayName("Arraival Time")]
        [DataType(DataType.Time)]
        public string ArrivalTime { get; set; }
        [DisplayName("Departure Time")]
        [DataType(DataType.Time)]
        public string DepartureTime { get; set; }
        [DisplayName("Train Capacity")]
        public int? AvailableSeats { get; set; }
        [DisplayName("Number of AC1 Coaches")]
        public int? NAc1Coaches { get; set; }
        [DisplayName("Number of AC2 Coaches")]
        public int? NAc2Coaches { get; set; }
        [DisplayName("Number of AC3 Coaches")]
        public int? NAc3Coaches { get; set; }
        [DisplayName("Number of Sleeper Coaches")]
        public int? NSlCoaches { get; set; }
        [DisplayName("Number of Second Sitting Coaches")]
        public int? NSsCoaches { get; set; }
        [DisplayName("Number of General Coaches")]
        public int? NGeneralCoaches { get; set; }
        [DisplayName("Train Runs On")]
        public string RunsOn { get; set; }
        [DisplayName("Is Deleted")]
        public bool IsDeleted { get; set; }
        [DisplayName("Train Type")]
        public string TrainType { get; set; }

        [DisplayName("Destination Station Name")]
        public virtual Station TdestinationNavigation { get; set; }
        [DisplayName("Source Station Name")]
        public virtual Station TsourceNavigation { get; set; }
        public virtual ICollection<Reach> Reaches { get; set; }
        public virtual ICollection<TrainStatus> TrainStatuses { get; set; }
    }
}
