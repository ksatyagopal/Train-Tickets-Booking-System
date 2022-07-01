using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BookMyTrainApp.Models
{
    public partial class StationDistance
    {
        public int Id { get; set; }
        [DisplayName("Station A")]
        public string StationA { get; set; }
        [DisplayName("Station B")]
        public string StationB { get; set; }
        [DisplayName("Distance in Kilometers")]
        public int? Distance { get; set; }
        [DisplayName("Station A Name")]
        public virtual Station StationANavigation { get; set; }
        [DisplayName("Station B Name")]
        public virtual Station StationBNavigation { get; set; }
    }
}
