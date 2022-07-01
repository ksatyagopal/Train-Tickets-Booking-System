using System;
using System.Collections.Generic;

#nullable disable

namespace BookMyTrainAPI.Models
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

        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string StationLocation { get; set; }
        public int? HaultTime { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Reach> Reaches { get; set; }
        public virtual ICollection<StationDistance> StationDistanceStationANavigations { get; set; }
        public virtual ICollection<StationDistance> StationDistanceStationBNavigations { get; set; }
        public virtual ICollection<Train> TrainTdestinationNavigations { get; set; }
        public virtual ICollection<Train> TrainTsourceNavigations { get; set; }
    }
}
