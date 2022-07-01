using System;
using System.Collections.Generic;
using System.ComponentModel;
#nullable disable

namespace BookMyTrainAdminClientApp.Models
{
    public partial class Station
    {
        public Station()
        {
            Reaches = new HashSet<Reach>();
            StationDistanceStationANavigations = new HashSet<StationDistance>();
            StationDistanceStationBNavigations = new HashSet<StationDistance>();
            TrainTdestinationNavigations = new HashSet<Train>();
            TrainTsourceNavigations = new HashSet<Train>();
        }

        [DisplayName("Station Code")]
        public string StationCode { get; set; }
        [DisplayName("Station Name")]
        public string StationName { get; set; }
        [DisplayName("Station Location")]
        public string StationLocation { get; set; }
        [DisplayName("Hault Time")]
        public int? HaultTime { get; set; }
        [DisplayName("Is Deleted")]
        public bool IsDeleted { get; set; }

        public virtual ICollection<Reach> Reaches { get; set; }
        public virtual ICollection<StationDistance> StationDistanceStationANavigations { get; set; }
        public virtual ICollection<StationDistance> StationDistanceStationBNavigations { get; set; }
        public virtual ICollection<Train> TrainTdestinationNavigations { get; set; }
        public virtual ICollection<Train> TrainTsourceNavigations { get; set; }
    }
}
